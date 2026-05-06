using SDAWorshipDraft.Types;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Text.Json;

namespace SDAWorshipDraft
{
    public partial class Form1 : Form
    {
        private BindingList<FormElement> elements = [];
        private List<string> selectOptions = [];
        private int highlightedRow = -1;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        private Dictionary<string, string> config = [];
        private int printIndex = 0;
        private TableLayoutPanel? editorTable;

        public Form1()
        {
            InitializeComponent();
            LoadConfig();
            LoadFieldTypesList();
            LoadHymnsList();
            
            elements.ListChanged += Elements_ListChanged;
        }

        private void LoadFieldTypesList()
        {
            FieldTypesList.Items.Add(new FormElement
            {
                Type = FormElementTypes.Label,
                Label = "Новый пункт"
            });
            FieldTypesList.Items.Add(new FormElement
            {
                Type = FormElementTypes.Input,
                Label = "Пункт с ответственным",
                Value = "Ответственный"
            });
            FieldTypesList.Items.Add(new FormElement
            {
                Type = FormElementTypes.Select,
                Label = "Гимн"
            });
            FieldTypesList.Items.Add(new FormElement
            {
                Type = FormElementTypes.Title,
                Label = "Заголовок"
            });
            FieldTypesList.SelectedIndex = 0;
        }

        private void LoadHymnsList()
        {
            try
            {
                selectOptions = TryLoadFromFile<List<string>>("data/hymns.json");
            }
            catch (JsonException jex)
            {
                MessageBox.Show($"Ошибка чтения данных: {jex.Message}", "Ошибка JSON");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void LoadConfig()
        {
            try
            {
                config = TryLoadFromFile<Dictionary<string, string>>(".config/config.json");
            }
            catch (JsonException jex)
            {
                MessageBox.Show($"Ошибка чтения данных: {jex.Message}", "Ошибка JSON");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void Elements_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded ||
                e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.Reset)
            {
                RenderEditor();
            }
        }

        private void RenderEditor()
        {
            panel1.SuspendLayout();

            if (editorTable == null)
            {
                editorTable = new TableLayoutPanel
                {
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    ColumnCount = 4,
                    AllowDrop = true
                };

                editorTable.DragOver += Table_DragOver;
                editorTable.DragDrop += Table_DragDrop;

                editorTable.CellPaint += (s, e) =>
                {
                    if (e.Row == highlightedRow)
                    {
                        using (Pen pen = new Pen(Color.Blue, 2))
                        {
                            e.Graphics.DrawLine(
                                pen,
                                e.CellBounds.Left,
                                e.CellBounds.Top,
                                e.CellBounds.Right,
                                e.CellBounds.Top
                            );
                        }
                    }

                    if (highlightedRow == editorTable.RowCount && e.Row == editorTable.RowCount - 1)
                    {
                        using (Pen pen = new Pen(Color.Blue, 2))
                        {
                            e.Graphics.DrawLine(
                                pen,
                                e.CellBounds.Left,
                                e.CellBounds.Bottom,
                                e.CellBounds.Right,
                                e.CellBounds.Bottom
                            );
                        }
                    }
                };

                panel1.Controls.Add(editorTable);
            }

            editorTable.SuspendLayout();

            editorTable.Controls.Clear();
            editorTable.RowStyles.Clear();

            editorTable.RowCount = elements.Count;

            editorTable.ColumnStyles.Clear();
            editorTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            editorTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            editorTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
            editorTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));

            int row = 0;

            foreach (FormElement element in elements)
            {
                editorTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

                TextBox textBox = new TextBox
                {
                    Dock = DockStyle.Fill,
                    Text = element.Label
                };
                textBox.TextChanged += (s, e) => element.Label = textBox.Text;

                Control? control = element.Type switch
                {
                    FormElementTypes.Input => CreateBoundTextBox(element),
                    FormElementTypes.Select => CreateBoundComboBox(element, selectOptions),
                    _ => null
                };

                editorTable.Controls.Add(textBox, 0, row);

                if (control != null)
                {
                    editorTable.Controls.Add(control, 1, row);
                }

                Button btnDelete = new Button
                {
                    Text = "❌",
                    Dock = DockStyle.Fill
                };
                btnDelete.Click += (s, e) => elements.Remove(element);
                editorTable.Controls.Add(btnDelete, 2, row);

                Label dnd = new Label
                {
                    Text = "⋮⋮",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.SizeAll
                };

                dnd.MouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                        dnd.DoDragDrop(element, DragDropEffects.Move);
                };

                dnd.QueryContinueDrag += (s, e) =>
                {
                    if (e.Action == DragAction.Cancel || e.Action == DragAction.Drop)
                    {
                        highlightedRow = -1;
                        editorTable?.Invalidate();
                    }
                };

                editorTable.Controls.Add(dnd, 3, row);

                row++;
            }

            editorTable.ResumeLayout();
            panel1.ResumeLayout();
        }

        private void RenderPreview()
        {
            panel2.Controls.Clear();

            TableLayoutPanel table = new TableLayoutPanel();
            table.AutoSize = true;
            table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            table.Dock = DockStyle.Top;
            table.ColumnCount = 2;
            table.RowCount = elements.Count;

            table.ColumnStyles.Clear();

            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));

            int row = 0;

            foreach (FormElement element in elements)
            {
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Label label = new()
                {
                    Text = element.Label,
                    Font = new Font(this.Font, FontStyle.Bold),
                    AutoSize = true,
                    Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3, 8, 10, 3)
                };
                if (element.Type == FormElementTypes.Title)
                {
                    label.Font = new Font(
                        this.Font.FontFamily,
                        this.Font.Size + 4,
                        FontStyle.Bold
                    );
                }

                table.Controls.Add(label, 0, row);

                if (element.Type is FormElementTypes.Input or FormElementTypes.Select)
                {
                    Label lValue = new()
                    {
                        Text = element.Value,
                        Margin = new Padding(3, 8, 10, 3),
                        AutoSize = true,
                        Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right,
                        Dock = DockStyle.Fill
                    };

                    table.Controls.Add(lValue, 1, row);
                }

                row++;

                Panel line = new()
                {
                    Height = 1,
                    Dock = DockStyle.Fill,
                    BackColor = Color.Gray,
                    Margin = new Padding(0, 0, 0, 5)
                };

                table.RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
                table.Controls.Add(line, 0, row);
                table.SetColumnSpan(line, 2);

                row++;
            }

            panel2.Controls.Add(table);
        }

        private TextBox CreateBoundTextBox(FormElement el)
        {
            TextBox tb = new()
            {
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };
            tb.DataBindings.Add("Text", el, nameof(el.Value), false, DataSourceUpdateMode.OnPropertyChanged);
            return tb;
        }

        private ComboBox CreateBoundComboBox(FormElement element, List<string> options)
        {
            ComboBox combo = new()
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                DropDownStyle = ComboBoxStyle.DropDown,
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.ListItems
            };

            combo.Items.AddRange(options.ToArray());

            if (!string.IsNullOrEmpty(element.Value))
            {
                if (options.Contains(element.Value))
                {
                    combo.SelectedItem = element.Value;
                }
                else
                {
                    combo.Text = element.Value;
                }
            }

            combo.SelectedIndexChanged += (s, e) =>
            {
                element.Value = combo.SelectedItem?.ToString() ?? "";
            };

            return combo;
        }

        private T TryLoadFromFile<T>(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"Файл {filepath} не найден");
            }

            string json = File.ReadAllText(filepath);
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new JsonException("Файл конфигурации поврежден. Переустановите приложение или обратитесь к разработчику");
            }

            return JsonSerializer.Deserialize<T>(json) ?? throw new JsonException("Не удалось преобразовать содержимое файла в объект.");
        }

        private void AddFieldBtn_Click(object sender, EventArgs e)
        {
            if (FieldTypesList.SelectedItem is FormElement formElement)
            {
                elements.Add(formElement with { });
            }
        }

        private void SaveToFileBtn_Click(object sender, EventArgs e)
        {
            string jsonToSave = JsonSerializer.Serialize(elements, _jsonOptions);
            File.WriteAllText("struct.json", jsonToSave);

            MessageBox.Show("Успешно сохранено!", "Успех");
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            if (elements.Count > 0)
            {
                elements.Clear();
            }
        }

        private void tabStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabStates.SelectedTab == tabPagePreview)
            {
                RenderPreview();
            }
        }

        private void LoadFromFileMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var loadedData = TryLoadFromFile<BindingList<FormElement>>("struct.json");
                if (loadedData != null)
                {
                    elements.RaiseListChangedEvents = false;
                    elements.Clear();
                    foreach (FormElement item in loadedData)
                    {
                        elements.Add(item);
                    }
                    elements.RaiseListChangedEvents = true;
                    elements.ResetBindings();
                }
            }
            catch (JsonException jex)
            {
                MessageBox.Show($"Ошибка чтения данных: {jex.Message}", "Ошибка JSON");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            printIndex = 0;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            float width = e.MarginBounds.Width;

            StringFormat format = new StringFormat();
            format.FormatFlags = StringFormatFlags.LineLimit;

            Graphics? graph = e.Graphics;
            if (graph == null) return;

            while (printIndex < elements.Count)
            {
                FormElement item = elements[printIndex];
                string line = item.Type == FormElementTypes.Label
                    ? item.Label
                    : $"{item.Label}: {item.Value}";

                Font font = item.Type == FormElementTypes.Title
                    ? new Font("Arial", 16, FontStyle.Bold)
                    : new Font("Arial", 12);

                SizeF size = graph.MeasureString(line, font, (int)width, format);

                if (y + size.Height > e.MarginBounds.Bottom)
                {
                    e.HasMorePages = true;
                    return;
                }

                RectangleF rect = new RectangleF(x, y, width, size.Height);
                graph.DrawString(line, font, Brushes.Black, rect, format);

                y += size.Height + 15;
                printIndex++;
            }

            e.HasMorePages = false;
            printIndex = 0;
        }

        private void Table_DragOver(object sender, DragEventArgs e)
        {
            if (sender is not TableLayoutPanel table || e.Data == null || !e.Data.GetDataPresent(typeof(FormElement)))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = DragDropEffects.Move;

            Point clientPoint = table.PointToClient(new Point(e.X, e.Y));
            int row = GetRowFromPoint(table, clientPoint);

            if (row != highlightedRow)
            {
                highlightedRow = row;
                table?.Invalidate();
            }
        }

        private void Table_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data?.GetData(typeof(FormElement)) is not FormElement draggedElement)
                return;

            if (sender is not TableLayoutPanel table)
                return;

            Point clientPoint = table.PointToClient(new Point(e.X, e.Y));
            int targetRow = GetRowFromPoint(table, clientPoint);

            int oldIndex = elements.IndexOf(draggedElement);
            if (oldIndex == -1)
                return;

            if (targetRow == oldIndex || targetRow == oldIndex + 1)
            {
                highlightedRow = -1;
                table?.Invalidate();
                return;
            }

            int targetIndex = targetRow;

            if (targetIndex > oldIndex)
                targetIndex--;

            elements.RaiseListChangedEvents = false;
            try
            {
                elements.RemoveAt(oldIndex);
                elements.Insert(targetIndex, draggedElement);
            }
            finally
            {
                elements.RaiseListChangedEvents = true;
            }

            MoveRow(table, oldIndex, targetIndex);

            highlightedRow = -1;
            table?.Invalidate();
        }

        private int GetRowFromPoint(TableLayoutPanel table, Point point)
        {
            int y = point.Y;

            int currentY = 0;
            int[] heights = table.GetRowHeights();

            for (int i = 0; i < heights.Length; i++)
            {
                int rowHeight = heights[i];
                int middle = currentY + rowHeight / 2;

                if (y < middle)
                    return i;

                currentY += rowHeight;
            }

            return heights.Length;
        }

        private async void LoadFromWebMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (config != null && config.TryGetValue("url", out string? value))
                {
                    using HttpClient client = new HttpClient();
                    this.Cursor = Cursors.WaitCursor;
                    var response = await client.GetFromJsonAsync<BindingList<FormElement>>(value);
                    if (response != null)
                    {
                        elements.RaiseListChangedEvents = false;
                        elements.Clear();
                        foreach (FormElement item in response)
                        {
                            elements.Add(item);
                        }
                        elements.RaiseListChangedEvents = true;
                        elements.ResetBindings();
                        RenderPreview();
                    }
                }
                else
                {
                    MessageBox.Show("Отсутствует необходимы параметр url", "Ошибка JSON");
                    return;
                }
            }
            catch (JsonException jex)
            {
                MessageBox.Show($"Ошибка чтения данных: {jex.Message}", "Ошибка JSON");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm about = new())
            {
                about.ShowDialog();
            }
        }

        private void MoveRow(TableLayoutPanel table, int fromRow, int toRow)
        {
            if (fromRow == toRow)
                return;

            table.SuspendLayout();

            int columnCount = table.ColumnCount;

            Control[] rowControls = new Control[columnCount];

            for (int col = 0; col < columnCount; col++)
            {
                rowControls[col] = table.GetControlFromPosition(col, fromRow);
            }

            int step = fromRow < toRow ? 1 : -1;

            for (int row = fromRow; row != toRow; row += step)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    var ctrl = table.GetControlFromPosition(col, row + step);
                    if (ctrl != null)
                        table.SetRow(ctrl, row);
                }
            }

            for (int col = 0; col < columnCount; col++)
            {
                if (rowControls[col] != null)
                    table.SetRow(rowControls[col], toRow);
            }

            table.ResumeLayout();
        }
    }
}
