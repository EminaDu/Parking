using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Car : Vehicle
    {
        public bool ElectricCar { get; set; }

        public Car()
        {
            Random rnd = new Random();
            ElectricCar = Convert.ToBoolean(rnd.Next(0, 2));
        }

        public override void Details()
        {

        }




    }
}
