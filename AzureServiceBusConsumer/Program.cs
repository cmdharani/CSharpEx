using Azure.Messaging.ServiceBus;

Console.WriteLine("Hello, World!");

string connectionString = @"Endpoint=sb://mdservicebustest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=3qWGxZOwScKx288DSJ23QMPFVCpbQDrdb+ASbBeWQZE=";


const string queueNameInServiceBus = "mdservicequeue";
ServiceBusClient client;
ServiceBusProcessor processor = default!;

async Task MessageHandler(ProcessMessageEventArgs processMessageEventArgs)
{
    string body = processMessageEventArgs.Message.Body.ToString();
    Console.WriteLine(body);
    await processMessageEventArgs.CompleteMessageAsync(processMessageEventArgs.Message);
}


Task ErrorHandler(ProcessErrorEventArgs processErrorEventArgs)
{
    Console.WriteLine(processErrorEventArgs.Exception.ToString());
    return Task.CompletedTask;
}

client = new ServiceBusClient(connectionString);
processor = client.CreateProcessor(queueNameInServiceBus, new ServiceBusProcessorOptions());

try
{
    processor.ProcessMessageAsync += MessageHandler;
    processor.ProcessErrorAsync += ErrorHandler;

    await processor.StartProcessingAsync();
    Console.WriteLine("press any key to end the processing");
    Console.ReadKey();

    Console.WriteLine("\n stopping the receiver");
    await processor.StopProcessingAsync();
    Console.WriteLine("stopped the receiver");

}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}
finally
{
    await processor.DisposeAsync();
    await client.DisposeAsync();
}