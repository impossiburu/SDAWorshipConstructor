using System.ComponentModel;

namespace SDAWorshipDraft.Interfaces
{
    public interface IHttpService
    {
        Task<BindingList<FormElement>> LoadAsync(string url);
    }
}
