using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SiaConsulting.Azure.WebJobs.Extensions.EventStoreExtension.Streams;

namespace ServerlessEventStore.App
{
    public static class ReadEvents
    {
        [FunctionName("ReadEvents")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, 
                "get", Route = "read-events/{eventStream}")] 
            HttpRequest req,
            [EventStoreStreams(
                ConnectionStringSetting="EventStoreConnection", 
                StreamName="{eventStream}", 
                StreamReadDirection=StreamReadDirection.Forward)]
            IList<ResolvedEvent> data,
            Microsoft.Extensions.Logging.ILogger log)
        {
            var events = data
                .Select(e => {

                    var eventData = JsonConvert
                        .DeserializeObject<dynamic>(Encoding.UTF8.GetString(e.Event.Data));
                    eventData.EventType = e.Event.EventType;

                    return eventData;
                })
                .ToList();

            return new OkObjectResult(events);
        }
    }
}