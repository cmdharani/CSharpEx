using AzureEx.Data;

namespace AzureEx.Service
{
    public interface ITableStorageService
    {
        Task DeleteAttendee(string industry, string id);
        Task<AttendeeEntity> GetAttendee(string industry, string id);
        Task<List<AttendeeEntity>> GetAttendees();
        Task UpdateAttendee(AttendeeEntity attendeeEntity);
    }
}