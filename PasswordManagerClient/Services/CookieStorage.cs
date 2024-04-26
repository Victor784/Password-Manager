using Microsoft.JSInterop;

namespace PasswordManagerClient.Services
{
    public class CookieStorageAccessor
    {
        private Lazy<IJSObjectReference> _accessorJsRef = new();
        private readonly IJSRuntime _jsRuntime;

        public CookieStorageAccessor(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        private async Task WaitForReference()
        {
            if (_accessorJsRef.IsValueCreated is false)
            {
                _accessorJsRef = new(await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "/CookieStorageAccessor.js"));
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_accessorJsRef.IsValueCreated)
            {
                await WaitForReference();
                // At log out setting the token to empty string as deleting the cookie seems to not work currently
                await _accessorJsRef.Value.InvokeVoidAsync("set", "token", "");
            }
        }

        public async Task<string> GetValueAsync(string key)
        {
            await WaitForReference();
            var result = await _accessorJsRef.Value.InvokeAsync<string>("get", key);

            string[] parts = result.Split('=');

            // Access the second part (index 1) after the '=' sign
            string valuePart = parts.Length > 1 ? parts[1] : string.Empty;

            return valuePart;
        }

        public async Task SetValueAsync<T>(string key, T value)
        {
            await WaitForReference();
            await _accessorJsRef.Value.InvokeVoidAsync("set", key, value);
        }
    }
}
