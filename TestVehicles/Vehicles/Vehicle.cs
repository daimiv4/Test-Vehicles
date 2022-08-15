using System;
using TestVehicles.Vehicles.Data;

namespace TestVehicles.Vehicles
{
    public abstract class Vehicle
    {
        /// <summary>
        /// Тип автомобиля
        /// </summary>
        public VehicleType Type { get; private set; }
        
        /// <summary>
        /// Расход топлива (расход литров / на километр движения)
        /// </summary>
        public (float FuelConsumption, int Kilometers) FuelConsumptionPerKilometers { get; private set; }
        
        /// <summary>
        /// Средняя скорость движения км/ч
        /// </summary>
        public int AverageSpeed { get; private set; }
        
        /// <summary>
        /// Объем топливного бака в литрах
        /// </summary>
        public float FuelTankCapacity { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="type">Тип автомобиля</param>
        /// <param name="fuelTankCapacity">Объем топливного бака в литрах</param>
        /// <param name="averageSpeed">Средняя скорость движения</param>
        /// <param name="fuelConsumption">Расход топлива на км (kilometers)</param>
        /// <param name="kilometers">километров в расходе топлива (по умолчанию 100)</param>
        protected Vehicle(VehicleType type, float fuelTankCapacity, int averageSpeed, float fuelConsumption, int kilometers = 100)
        {
            Type = type;
            FuelConsumptionPerKilometers = (fuelConsumption, kilometers);
            FuelTankCapacity = fuelTankCapacity;
            AverageSpeed = averageSpeed;
        }

        /// <summary>
        /// Получить максимальное расстояние которое преодолеет автомобиль с полным баком
        /// </summary>
        /// <returns>Дистанция в км</returns>
        public virtual float GetRangeOfTravel() 
        {
            return (FuelConsumptionPerKilometers.Kilometers * FuelTankCapacity) / FuelConsumptionPerKilometers.FuelConsumption;
        }

        /// <summary>
        /// Получить время за которое автомобиль проедет указанное расстояние
        /// </summary>
        /// <param name="fuelVolumeL">Требуется топлива литрах</param>
        /// <param name="distanceKm">Расстояние в км</param>
        /// <returns>Время</returns>
        public virtual TimeSpan GetTimeForTravelThisDistance(float distanceKm, out float fuelVolumeL)
        {
            ///Считаю, что в ТЗ некорректно указано:
            /// (Метод, который на основе параметров количества топлива и заданного расстояния вычисляет за сколько автомобиль его преодолеет)
            /// т.к. по условию объём топлива в баке не влияет на расход топлива, реализовал возврат методом - сколько топлива нужно для преодаления дистанции

            var hoursForDestination = distanceKm / AverageSpeed;
            var resultTime = TimeSpan.FromHours(hoursForDestination);
            fuelVolumeL = distanceKm * FuelConsumptionPerKilometers.FuelConsumption / FuelConsumptionPerKilometers.Kilometers;

            return resultTime;
        }
    }
}