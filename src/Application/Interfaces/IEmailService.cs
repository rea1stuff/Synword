namespace Synword.Application.Interfaces;

public interface IEmailService
{
    public Task SendConfirmationEmailAsync(string uId, string confirmationCode);
}
