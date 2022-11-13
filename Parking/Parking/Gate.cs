using Parking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    internal class Gate
    {

        Parking MyParking { get; set; }

        public Gate()
        {
            MyParking = new Parking();
        }
        public void Run()
        {
            bool runProgram = true;

            while (runProgram)
            {

                foreach (Vehicle vehicle in MyParking.Vehicles)
                {
                    vehicle.Details();
                }
                Menu();

                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();

                switch (key.KeyChar)
                {
                    case 'P':
                    case 'p':
                        MyParking.EnterParking(GetRandomVehicle());
                        break;
                    case 'L':
                    case 'l':
                        Console.WriteLine("Ange registrationnummer på fordon som lämnar: ");
                        string registrationNumber = Console.ReadLine().ToUpper();
                        if (ArePlatesValid(registrationNumber))
                        {
                            MyParking.LeaveParking(registrationNumber);
                        }
                        else
                        {
                            Console.Clear();
                            TryAgain();
                        }
                        break;
                    case 'e':
                    case 'E':
                        runProgram = false;
                        break;
                    default:
                        Instructions();
                        break;
                }
                Console.WriteLine();
            }
        }

        private bool ArePlatesValid(string licencePlates)
        {
            int index = 0;
            if (licencePlates.Length != 6)
            {
                return false;
            }
            foreach (char letter in licencePlates)
            {
                if (index < 3)
                {
                    if (letter < 65 || letter > 90)
                    {
                        return false;
                    }
                }
                else
                {
                    bool success = int.TryParse(letter.ToString(), out int number);
                    if (!success)
                    {
                        Console.WriteLine(letter);
                        return false;
                    }
                }
                index++;
            }
            return true;
        }

        private void TryAgain()
        {
            Console.WriteLine("Ogiltig registration nummer, försök igen! ");
        }

        private void Instructions()
        {
            Console.WriteLine("Velj nitt alternativ från menu!");
        }

        private void Menu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("====");
            Console.WriteLine("[P]arkera fordon");
            Console.WriteLine("[L]ämna parking");
            Console.WriteLine("[E]xit");
        }
        private Vehicle GetRandomVehicle()
        {
            Random rnd = new();
            int option = rnd.Next(0, 3);
            if (option == 0)
            {
                return new Car();
            }
            else if (option == 2)
            {
                return new Motorcycle();
            }
            else
            {
                return new Bus();
            }
        }
    }
}

