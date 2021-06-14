using System;
namespace kafka_producer_api.model
{
    public class Car
    {
        public string brandName { get; set; }
        public string model { get; set; }
        public int noOfDoors { get; set; }
        public bool isSportsCar { get; set; }
    }
}
