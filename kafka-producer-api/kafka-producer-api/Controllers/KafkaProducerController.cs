using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Confluent.Kafka;
using kafka_producer_api.model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace kafka_producer_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KafkaProducerController : ControllerBase
    {
        private ProducerConfig _config;

        public KafkaProducerController(ProducerConfig config)
        {
            this._config = config;
        }

        [HttpPost("produce")]
        public async Task<OkObjectResult> ProduceMessage(string topic, [FromBody] List<Car> objectLists)
        {
            using(var producer = new ProducerBuilder<Null, string>(_config).Build())
            {
                foreach (var msgObject in objectLists)
                {
                    var serializedDetails = JsonConvert.SerializeObject(msgObject);
                    await producer.ProduceAsync(topic, new Message<Null, string>
                    {
                        Value = serializedDetails
                    });
                }
                producer.Flush(TimeSpan.FromSeconds(10));
                return Ok(true);
            }
        }

        [HttpGet]
        public OkObjectResult Get()
        {
            Console.WriteLine();
            return Ok(true);
        }
    }
}
