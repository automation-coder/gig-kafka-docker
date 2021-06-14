using System;
using System.Diagnostics.CodeAnalysis;

namespace kafka_console_app.poco
{
    public class Car : IEquatable<Car>
    {
        public string brandName { get; set; }
        public string model { get; set; }
        public int noOfDoors { get; set; }
        public bool isSportsCar { get; set; }

        public bool Equals(Car otherCar)
        {
            return
                this.brandName.Equals(otherCar.brandName) &&
                this.model.Equals(otherCar.model) &&
                this.noOfDoors == otherCar.noOfDoors &&
                this.isSportsCar.CompareTo(otherCar.isSportsCar) == 0
                ;
        }
    }
}
