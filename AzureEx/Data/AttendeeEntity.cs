﻿using Azure;
using Azure.Data.Tables;

namespace AzureEx.Data
{
    public class AttendeeEntity : ITableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }   
        public string Industry { get; set; } 

        public string ImageName { get; set; }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
