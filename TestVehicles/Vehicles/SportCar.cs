using TestVehicles.Vehicles.Data;

namespace TestVehicles.Vehicles
{
    public class SportCar : Vehicle
    {
        public SportCar(VehicleType type, float fuelTankCapacity, int averageSpeed, float fuelConsumption, int kilometers = 100) :
            base(type, fuelTankCapacity, averageSpeed, fuelConsumption, kilometers)
        {
        }
    }
}