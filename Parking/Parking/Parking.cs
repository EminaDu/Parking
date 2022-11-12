using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Parking
    {

        public List<Double> ParkingPlaces { get; set; }

        public double PricePerMin { get; set; }

        public List<Vehicle> Vehicles { get; set; }

        public Parking()
        {
            ParkingPlaces = new List<double>();
            for (int i = 0; i < ParkingPlaces.Count; i++)
            {
                ParkingPlaces.Add(i);
            }
            PricePerMin = 1.5;
            Vehicles = new List<Vehicle>();
        }

        public void PrintReceipt(Vehicle vehicle)
        {
            Console.WriteLine("Lämnar:");
            vehicle.Details();
            DateTime leavingTime = DateTime.Now;
            TimeSpan totalTimeStay = leavingTime - vehicle.EntranceTime;
            double totalPrice = totalTimeStay.TotalMinutes * PricePerMin;
            Console.WriteLine("Det kostade:" + totalPrice);
        }

        public void LeaveParking(string registrationNumber)
        {
            int vehicleIndex = SearchVehicle(registrationNumber);
            if (vehicleIndex != -1)
            {
                Vehicle vehicleToLeave = Vehicles[vehicleIndex];
                PrintReceipt(vehicleToLeave);

                foreach (int ParkingPosition in vehicleToLeave.VehiclePosition)
                {
                    ParkingPlaces[ParkingPosition] += vehicleToLeave is Bus ? 1 : vehicleToLeave.SizeInParkingPlace;
                }
                Vehicles.RemoveAt(vehicleIndex);
            }
            else
            {
                Console.WriteLine("Fordonet hittades inte!");
            }
        }

        private int SearchVehicle(string registrationNumber)
        {
            for (int i = 0; i < Vehicles.Count; i++)
            {
                if (Vehicles[i].RegistrationNumber == registrationNumber)
                {
                    return i;
                }
            }
            return -1;
        }
        public void EnterParking(Vehicle vehicle)
        {
            List<int> takingParkingPlaces = TryParkingVehicle(vehicle);
            if (takingParkingPlaces.Count > 0)
            {
                vehicle.EnterParkigPlace(takingParkingPlaces);
                Vehicles.Add(vehicle);
            }
            else
            {
                Console.WriteLine("Fordon kan inte passa.");
            }
        }
        private List<int> TryParkingVehicle(Vehicle vehicle)
        {

            for (int i = 0; i < ParkingPlaces.Count; i++)
            {
                if (vehicle is Bus)
                {
                    if (i != ParkingPlaces.Count - 1)
                    {
                        if (vehicle.SizeInParkingPlace <= ParkingPlaces[i] + ParkingPlaces[i + 1])
                        {
                            ParkingPlaces[i] = 0;
                            ParkingPlaces[i + 1] = 0;
                            return new List<int> { i, i + 1 };
                        }

                    }
                }
                else
                {
                    if (vehicle.SizeInParkingPlace <= ParkingPlaces[i])
                    {
                        ParkingPlaces[i] -= vehicle.SizeInParkingPlace;
                        return new List<int> { i };
                    }
                }
            }
            return new List<int> { };
        }
    }
}

