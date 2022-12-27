using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacetedBuilder
{
    public class CarFacade
    {
        public CarFacade()
        {
            Car = new Car();
        }

        protected Car Car { get; set; }

        public CarInfoBuilder Info => new(Car);
        public CarAdressBuilder Adress => new(Car);

        public Car Build() => Car;
    }
}
