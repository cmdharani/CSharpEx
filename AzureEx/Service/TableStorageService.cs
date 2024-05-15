using Azure;
using Azure.Data.Tables;
using AzureEx.Data;

namespace AzureEx.Service
{
    public class TableStorageService : ITableStorageService
    {
        private readonly string TableName = "Attendee";
        private readonly IConfiguration _configuration;

        public TableStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AttendeeEntity> GetAttendee(string industry, string id)
        {
            var tableClient = await GetTableClient();
            return await tableClient.GetEntityAsync<AttendeeEntity>(industry, id);
        }

        public async Task<List<AttendeeEntity>> GetAttendees()
        {
            var tableClient = await GetTableClient();
            Pageable<AttendeeEntity> attendeeEntities = tableClient.Query<AttendeeEntity>();
            return attendeeEntities.ToList();
        }

        public async Task UpdateAttendee(AttendeeEntity attendeeEntity)
        {
            var tableClient = await GetTableClient();
            await tableClient.UpsertEntityAsync(attendeeEntity);

        }

        public async Task DeleteAttendee(string industry, string id)
        {

            var tableClient = await GetTableClient();
            await tableClient.DeleteEntityAsync(industry, id);
        }


        private async Task<TableClient> GetTableClient()
        {
            var serviceClient = new TableServiceClient(_configuration["StorageConnectionString"]);

            var tableClient = serviceClient.GetTableClient(TableName);
            await tableClient.CreateIfNotExistsAsync();

            return tableClient;
        }
    }
}
