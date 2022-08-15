using System.Collections.Generic;

namespace TestVehicles.Vehicles.Data
{
    public static class VehiclesConfiguration
    {
        /// <summary>
        /// Количество пассажирских мест в типах легковых автомобилей
        /// </summary>
        public static readonly Dictionary<VehicleType, int> PassengersSeats = new Dictionary<VehicleType, int>()
        {
            {VehicleType.Coupe, 1},
            {VehicleType.Sedan, 4}
        };
        
        /// <summary>
        /// грузоподъемность в типах грузовых автомобилей
        /// </summary>
        public static readonly Dictionary<VehicleType, float> MaxCargoWeight = new Dictionary<VehicleType, float>()
        {
            {VehicleType.Van, 1000f},
            {VehicleType.Pickup, 450f}
        };
    }
}