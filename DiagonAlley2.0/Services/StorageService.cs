using Microsoft.JSInterop;

namespace DiagonAlley2._0.Services
{
    public class StorageService
    {
        private readonly IJSRuntime _js;

        public StorageService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task SetWizardId(string wizardId)
        {
            await _js.InvokeVoidAsync("localStorage.setItem", "wizardId", wizardId);
        }

        public async Task<string?> GetWizardId()
        {
            return await _js.InvokeAsync<string?>(
                "localStorage.getItem", "wizardId");
        }

        public async Task ClearWizardId()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", "wizardId");
        }
    }

}
