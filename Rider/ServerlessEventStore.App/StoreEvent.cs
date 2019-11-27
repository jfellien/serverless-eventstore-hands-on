using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Streams;
using SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Streams.Bindings;

namespace ServerlessEventStore.App
{
    public static class StoreEvent
    {
        [FunctionName("StoreEvent")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "store-event")] 
            HttpRequest req,
            [EventStoreStreams(ConnectionStringSetting= "EventStoreConnection")]
            IAsyncCollector<EventStoreData> data,
            Microsoft.Extensions.Logging.ILogger log)
        {
            byte[] metaData = null;
            var eventID = Guid.NewGuid();

            var eventStream = req.Headers["x-related-event-stream"].ToString();
            var eventType = req.Headers["x-related-event-type"].ToString();
            var isJson = req.ContentType == "application/json";
            var requestBodyAsString = await req.Body.AsString();
            var requestBodyAsBytes = requestBodyAsString.AsBytes();

            // Set up Eventdata
            var eventData = new EventData(eventID, 
                eventType, 
                isJson, 
                requestBodyAsBytes, 
                metaData);

            // Attach to out-Binding
            await data.AddAsync(new EventStoreData
            {
                StreamName = eventStream,
                Events = new List<EventData> { eventData }
            });

            return new OkObjectResult("Done");
        }
    }

    static class StoreEventExtensions
    {
        public static async Task<string> AsString(this Stream source)
        {
            return await new StreamReader(source).ReadToEndAsync();
        }

        public static byte[] AsBytes(this string source)
        {
            return Encoding.UTF8.GetBytes(source);
        }
    }
}