// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");

string connectionString = @"Endpoint=sb://mdservicebustest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3qWGxZOwScKx288DSJ23QMPFVCpbQDrdb+ASbBeWQZE=";


const string queueNameInServiceBus = "mdservicequeue";
const int maxNumberOfMessages = 3;

ServiceBusClient client;
ServiceBusSender sender;

client = new ServiceBusClient(connectionString);
sender=client.CreateSender(queueNameInServiceBus);

ServiceBusMessageBatch batch=await sender.CreateMessageBatchAsync();

for(int i = 1; i < maxNumberOfMessages; i++)
{
    if(!batch.TryAddMessage(new ServiceBusMessage($"this is a message {i}")))
    {
        Console.WriteLine($"Message {i} was not able to add to the queue");
    }
}


try
{
    await sender.SendMessagesAsync(batch);
    Console.WriteLine("Message Sent");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    await sender.DisposeAsync();
    await client.DisposeAsync();

}