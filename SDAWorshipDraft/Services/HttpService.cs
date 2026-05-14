using SDAWorshipDraft.Interfaces;
using System.ComponentModel;
using System.Net.Http.Json;

namespace SDAWorshipDraft.Services
{
    public class HttpService(HttpClient httpClient) : IHttpService
    {
        public async Task<BindingList<FormElement>> LoadAsync(string url)
        {
            return await httpClient.GetFromJsonAsync<BindingList<FormElement>>(url)
                   ?? [];
        }
    }
}
