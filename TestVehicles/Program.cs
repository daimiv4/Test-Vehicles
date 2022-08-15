using System;
using TestVehicles.Vehicles;
using TestVehicles.Vehicles.Data;

namespace TestVehicles
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var renault = new PassengerCar(VehicleType.Sedan, 50f, 90, 10f);
            var dodge = new Truck(VehicleType.Pickup, 100f, 80, 40f);

            if (!renault.TryInitPassengersAtCar(3, out var errorText))
                Console.WriteLine(errorText);
            
            dodge.CargoWeight = 700f;
            
            renault.GetRangeOfTravel();
            dodge.GetRangeOfTravel();
            renault.GetTimeForTravelThisDistance(500f, out var renaultFuelVolumeL);
            dodge.GetTimeForTravelThisDistance(600f, out var dodgeFuelVolumeL);
        }
    }
}