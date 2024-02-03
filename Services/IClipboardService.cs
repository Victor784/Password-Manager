namespace PasswordManagerClient.Services
{
    public interface IClipboardService
    {
        Task CopyToClipboard(string text);
    }
}
