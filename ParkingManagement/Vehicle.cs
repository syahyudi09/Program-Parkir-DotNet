using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramParkir.ParkingManagement
{
    public class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public VehicleType VehicleType { get; set; }
        public int SlotNumber { get; set; }
        public DateTime DateEntered { get; set; } 

        // Constructor
        public Vehicle()
        {
            DateEntered = DateTime.Now;
        }
    }

    public enum VehicleType
    {
        Mobil,
        Motor
    }
}