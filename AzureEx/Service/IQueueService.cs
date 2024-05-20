using AzureEx.Data;

namespace AzureEx.Service
{
    public interface IQueueService
    {
        Task SendMessage(EmailMessage emailMessage);
    }
}