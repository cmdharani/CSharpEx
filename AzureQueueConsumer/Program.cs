// See https://aka.ms/new-console-template for more information
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System.Text;

Console.WriteLine("Hello, World!");

 String AzureConnectionString = @"DefaultEndpointsProtocol=https;AccountName=mdstorage;AccountKey=Su5D1e3CnGaspuq2dxyt1IPu7W5rqwxz8069QqouVqhvjaYEDuxOUEvXtwr2KivgfDd1MK9WZ1xa+AStJ4RJgA==;EndpointSuffix=core.windows.net";

QueueClient queue = new QueueClient(AzureConnectionString, "attendee-emails");

if(await queue.ExistsAsync())
{
    QueueProperties properties = await queue.GetPropertiesAsync();
    for(int i=0;i< properties.ApproximateMessagesCount;i++) 
    {
        string message = await RetrieveNextMessage();
        Console.WriteLine(message);
    }
}

async Task<string> RetrieveNextMessage()
{
    QueueMessage[] retrivedMessage = await queue.ReceiveMessagesAsync(1);
    var data = Convert.FromBase64String(retrivedMessage[0].Body.ToString());
    string theMessage=Encoding.UTF8.GetString(data);

    await queue.DeleteMessageAsync(retrivedMessage[0].MessageId, retrivedMessage[0].PopReceipt);

    return theMessage;
}