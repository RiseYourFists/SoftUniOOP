using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacetedBuilder
{
    public class CarAdressBuilder : CarFacade
    {
        public CarAdressBuilder(Car car)
        {
            Car = car;
        }

        public CarAdressBuilder WithCity(string city)
        {
            Car.City = city;
            return this;
        }

        public CarAdressBuilder WithAdress(string address)
        {
            Car.Address = address;
            return this;
        }
    }
}
