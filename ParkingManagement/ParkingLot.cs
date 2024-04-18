using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgramParkir.ParkingManagement
{
    public class ParkingLot
    {
        private List<Vehicle> parkedVehicles;
        private int capacity;
        private List<int> availableSlots;
        private Dictionary<VehicleType, int> entryFee;

        public ParkingLot(int initialCapacity)
        {
            capacity = initialCapacity;
            parkedVehicles = new List<Vehicle>(initialCapacity);
            availableSlots = new List<int>(initialCapacity);

            for (int i = 1; i <= initialCapacity; i++)
            {
                availableSlots.Add(i);
            }

            entryFee = new Dictionary<VehicleType, int>();
            entryFee[VehicleType.Mobil] = 2000;
            entryFee[VehicleType.Motor] = 3000;
        }

        public int Capacity { get { return capacity; } }

        

        public void CreateParkingLot()
        {
            Util.Message("create_parking_lot : ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int newCapacity))
            {
                capacity = newCapacity;
                parkedVehicles = new List<Vehicle>(newCapacity);

                availableSlots.Clear();
                for (int i = 1; i <= newCapacity; i++)
                {
                    availableSlots.Add(i);
                }
                Util.Message($"Created a parking lot with {newCapacity} slots");
            }
            else
            {
                Util.Message("Input Not Valid");
            }
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            if (parkedVehicles.Count >= capacity)
            {
                Util.Message("Sorry, parking lot is full");
                return;
            }

            int allocatedSlot = availableSlots[0];
            availableSlots.RemoveAt(0);

            vehicle.DateEntered = DateTime.Now;
            vehicle.SlotNumber = allocatedSlot;

            parkedVehicles.Add(vehicle);

            Util.Message($"Allocated slot number: {allocatedSlot}");
        }
        
        public bool LeaveSlot(int slotNumber)
        {
            if (slotNumber >= 1 && slotNumber <= capacity)
            {
                var vehicle = parkedVehicles.FirstOrDefault(v => v.SlotNumber == slotNumber);
                if (vehicle != null)
                {
                    DateTime now = DateTime.Now;
                    TimeSpan duration = now - vehicle.DateEntered; // Hitung durasi parkir

                    int hourlyRate = 2000;

                    int totalCost = (int)Math.Ceiling(duration.TotalHours) * hourlyRate;

                    parkedVehicles.Remove(vehicle);
                    availableSlots.Add(slotNumber);

                    Util.Message($"Slot number {slotNumber} is free. Total parking fee: {totalCost} rupiah");
                    return true;
                }
                else
                {
                    Util.Message($"Slot number {slotNumber} not found");
                    return false;
                }
            }
            else
            {
                Util.Message($"Invalid slot number: {slotNumber}");
                return false;
            }
        }

        public void CheckParkingStatus()
        {
            Util.Message("Slot No. Type Registration No Colour");
            foreach (var vehicle in parkedVehicles.OrderBy(v => v.SlotNumber))
            {
                Util.Message($"{vehicle.SlotNumber} {vehicle.RegistrationNumber} {vehicle.Color} {vehicle.VehicleType}");
            }
        }

        public void AvailableSlots()
        {
            int avaliable = capacity - parkedVehicles.Count;
            Util.Message($"Jumlah slot yang tersedia: {avaliable}");
        }


        public void OccupiedSlots() 
        { 
            int slot = parkedVehicles.Count();
            Util.Message($"Jumlah slot terisi: {slot}");
        }

        public void CountVehiclesByOddCount()
        {
            int oddCount = parkedVehicles.Count(v => v.SlotNumber % 2 != 0);

            Util.Message($"Odd Slots: {oddCount}");
        }

        public void CountVehiclesByEvenCount()
        {
            int evenCount = parkedVehicles.Count(v => v.SlotNumber % 2 == 0);
            Util.Message($"Even Slots: {evenCount}");
        }

        public void CountVehiclesByType()
        {
            var countByType = parkedVehicles.GroupBy(v => v.VehicleType)
                                            .Select(g => new { Type = g.Key, Count = g.Count() });

            foreach (var group in countByType)
            {
                Util.Message($"Type: {group.Type}, Count: {group.Count}");
            }
        }

        public void CountVehiclesByColor()
        {
            var countByColor = parkedVehicles.GroupBy(v => v.Color)
                                             .Select(g => new { Color = g.Key, Count = g.Count() });

            foreach (var group in countByColor)
            {
                Util.Message($"Color: {group.Color}, Count: {group.Count}");
            }
        }
    }
}
