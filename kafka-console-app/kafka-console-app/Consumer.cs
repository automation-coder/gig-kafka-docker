using System;
using System.Collections.Generic;
using System.Linq;
using kafka_console_app.poco;
using kafka_console_app.services;
using kafka_console_app.util;

namespace kafka_console_app
{
    public class Consumer
{
    public static void Main(string[] args)
    {
            KafkaConsumerService kafkaConsumerService = new KafkaConsumerService("localhost:9092");
            List<Car> consumedCarDetails = kafkaConsumerService.ConsumeMessages<Car>("car");
            Console.WriteLine("No. of Messages Received : "+consumedCarDetails.Count);
            List<Car> expectedCarDetails = new List<Car>();
            expectedCarDetails = JsonActions.CreateObjectFromJson<List<Car>>("/messages/car.json");
            if (expectedCarDetails.Count == consumedCarDetails.Count &&
                    expectedCarDetails.SequenceEqual(consumedCarDetails))
            {
                Console.WriteLine("Produced and Consumed Messages are identical");
            }
            else
            {
                Console.WriteLine("Produced and Consumed messages are not identical");
            }
        }
}
}
