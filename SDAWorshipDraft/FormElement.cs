using System;
using System.Collections.Generic;
using System.Text;

namespace SDAWorshipDraft
{
    public record FormElement
    {
        public string Type { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public override string ToString() => Label;
    }
}
