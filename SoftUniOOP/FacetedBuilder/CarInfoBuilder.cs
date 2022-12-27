using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacetedBuilder
{
    public class CarInfoBuilder : CarFacade
    {
        public CarInfoBuilder(Car car)
        {
            Car = car;
        }


        public CarInfoBuilder WithType(string type)
        {
            Car.Type = type;
            return this;
        }

        public CarInfoBuilder WithColor(string color)
        {
            Car.Color = color;
            return this;
        }

        public CarInfoBuilder WithDoors(int numOfDoors)
        {
            Car.NumberOfDoors = numOfDoors;
            return this;
        }
    }
}
