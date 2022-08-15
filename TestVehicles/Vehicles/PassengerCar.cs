using System;
using TestVehicles.Vehicles.Data;

namespace TestVehicles.Vehicles
{
    public class PassengerCar : Vehicle
    {
        /// <summary>
        /// Уменьшение запаса хода в процентах на одного пассажира
        /// </summary>
        public const int OnePassengerReducesThePowerReserve = 6;

        /// <summary>
        /// Количество пассажиров (без водителя)
        /// </summary>
        public int PassengerCount { get; private set; }

        public PassengerCar(VehicleType type, float fuelTankCapacity, int averageSpeed, float fuelConsumption, int kilometers = 100) :
            base(type, fuelTankCapacity, averageSpeed, fuelConsumption, kilometers)
        {
        }

        /// <summary>
        /// Установить количество пассажиров
        /// </summary>
        /// <param name="passengersCount"></param>
        public bool TryInitPassengersAtCar(int passengersCount, out string errorText)
        {
            errorText = GetErrorBeforeInitPassengers(passengersCount);

            if (!string.IsNullOrEmpty(errorText))
                return false;
            
            PassengerCount = passengersCount;
            return true;
        }

        public override float GetRangeOfTravel()
        {
            var freeRange = base.GetRangeOfTravel();
            var resultRange = freeRange - (freeRange / 100f) * GetReducesOfPowerReserve();

            return resultRange;
        }

        private string GetErrorBeforeInitPassengers(int passengersCount)
        {
            if (VehiclesConfiguration.PassengersSeats.TryGetValue(Type, out var maxPassengersCount))
                throw new Exception(Text.ThisVehicleIsNotContainsConfiguration);

            if (passengersCount < 0)
                return Text.TheValueCannotBeLessThan0;

            if (passengersCount > maxPassengersCount)
                return Text.TheNumberOfPassengersExceedsThePermissibleNumber;

            return string.Empty;
        }

        private int GetReducesOfPowerReserve()
        {
            return OnePassengerReducesThePowerReserve * PassengerCount;
        }
    }
}