using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public string VehicleColor { get; set; }
        public double SizeInParkingPlace { get; set; }
        public DateTime EntranceTime { get; set; }
        public List<int> VehiclePosition { get; set; }

        public Vehicle()
        {
            RegistrationNumber = GenerateRegistrationNumber();
            VehicleColor = GenerateVehicleColor();
            SizeInParkingPlace = 1;
            EntranceTime = new DateTime();
            VehiclePosition = new List<int>();
        }

        private string GenerateVehicleColor()
        {
            Random rnd = new Random();
            string[] colors = new string[] { "Blå", "Röd", "Svart", "Vit", "Grön", "Grå", "Silver", "Gul", "Brun" };

            return colors[rnd.Next(colors.Length)];
        }



        private string GenerateRegistrationNumber()
        {
            Random rnd = new();
            string regNumber = "";
            for (int i = 0; i < 3; i++)
            {
                regNumber += char.ConvertFromUtf32(rnd.Next(65, 91));
            }
            for (int i = 0; i < 3; i++)
            {
                regNumber += rnd.Next(0, 10).ToString();
            }
            return regNumber;
        }

        public virtual void Details()
        {

        }

        public void EnterParkigPlace(List<int> parkingPosition)
        {
            EntranceTime = DateTime.Now;
            VehiclePosition = parkingPosition;
        }

    }
}
