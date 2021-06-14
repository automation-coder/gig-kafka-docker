using System;
using System.Collections.Generic;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace kafka_console_app.services
{
    public class KafkaConsumerService
    {
        private static ConsumerConfig _config;
        private const string GROUP_ID = "test-group";
        private const long CONSUMER_TIME_OUT = 30;

        public KafkaConsumerService(string bootstrapServer)
        {
            _config = new ConsumerConfig()
            {
                BootstrapServers = bootstrapServer,
                GroupId = GROUP_ID,
                AutoOffsetReset = AutoOffsetReset.Latest
            };
        }

        public List<T> ConsumeMessages<T>(string topic)
        {
            using (var consumerBuilder = new ConsumerBuilder<Null, string>(_config).Build())
            {
                List<T> objects = new List<T>();
                consumerBuilder.Subscribe(topic);
                while (true)
                {
                    var consumedMessages = consumerBuilder.Consume(TimeSpan.FromSeconds(CONSUMER_TIME_OUT));
                    if(consumedMessages == null)
                    {
                        break;
                    }
                    Console.WriteLine(consumedMessages.Message.Value);
                    T obj = JsonConvert.DeserializeObject<T>(consumedMessages.Message.Value);
                    objects.Add(obj);
                }
                consumerBuilder.Close();
                return objects;
            }
        }
    }
}
