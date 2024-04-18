using System;
using System.Collections.Generic;

namespace ProgramParkir.ParkingManagement
{
    public class ParkingManager
    {
        private ParkingLot parkingLot;

        public ParkingManager(int initialCapacity)
        {
            parkingLot = new ParkingLot(initialCapacity);
        }

        public void CreateParkingLot()
        {
            parkingLot.CreateParkingLot();
        }

        public void ParkVehicle(string registrationNumber, string color, string type)
        {
            Util.Message("Park");
            VehicleType vehicleType;
            

             if (!Enum.TryParse(type, true, out vehicleType) || (vehicleType != VehicleType.Mobil && vehicleType != VehicleType.Motor))
            {
                Util.Message("Pilihan jenis kendaraan tidak valid.");
                return;
            }

            Vehicle vehicle = new Vehicle
            {
                RegistrationNumber = registrationNumber,
                Color = color,
                VehicleType = vehicleType,
            };

            parkingLot.ParkVehicle(vehicle);
            
        }

        // untuk mengeluarkan kendaraan
        public bool LeaveSlot(int slotNumber)
        {
            return parkingLot.LeaveSlot(slotNumber);
        }

        public void CheckingParkingStatus()
        {
            parkingLot.CheckParkingStatus();
        }

        public void GetOccupiedSlots()
        {
             parkingLot.OccupiedSlots(); 
        }

        public void GetAvaliableSlot()
        {
            parkingLot.AvailableSlots();
        }

        public void CountVehiclesByOddCount()
        {
            parkingLot.CountVehiclesByOddCount();
        }

        public void CountVehiclesByEvenCount()
        {
            parkingLot.CountVehiclesByEvenCount();
        }

        public void CountVehiclesByType()
        {
            parkingLot.CountVehiclesByType();
        }

        public void CountVehiclesByColor()
        {
            parkingLot.CountVehiclesByColor();
        }

    }
}
