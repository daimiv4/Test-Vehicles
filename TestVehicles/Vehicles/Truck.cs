using System;
using TestVehicles.Vehicles.Data;

namespace TestVehicles.Vehicles
{
    public class Truck : Vehicle
    {
        /// <summary>
        /// Уменьшение запаса хода в процентах на 200кг
        /// </summary>
        public readonly (int Percent, int Kilograms) ReducesThePowerReserve = (4, 200);

        /// <summary>
        /// Вес груза
        /// </summary>
        public float CargoWeight
        {
            get => _cargoWeight;
            set
            {
                if (VehiclesConfiguration.MaxCargoWeight.TryGetValue(Type, out var maxCargoWeight))
                    throw new Exception(Text.ThisVehicleIsNotContainsConfiguration);

                if (value < 0)
                    _cargoWeight = 0;
                else if (value > maxCargoWeight)
                    _cargoWeight = maxCargoWeight;
                else
                    _cargoWeight = value;
            }
        }

        private float _cargoWeight;

        public Truck(VehicleType type, float fuelTankCapacity, int averageSpeed, float fuelConsumption, int kilometers = 100) :
            base(type, fuelTankCapacity, averageSpeed, fuelConsumption, kilometers)
        {
        }

        public override float GetRangeOfTravel()
        {
            var freeRange = base.GetRangeOfTravel();
            var resultRange = freeRange - (freeRange / 100f) * GetReducesOfPowerReserve();

            return resultRange;
        }
        
        private float GetReducesOfPowerReserve()
        {
            return (CargoWeight / ReducesThePowerReserve.Kilograms) * ReducesThePowerReserve.Percent;
        }
    }
}