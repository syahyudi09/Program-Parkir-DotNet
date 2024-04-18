using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramParkir.ParkingManagement
{
    public class Util
    {
        public static void Menu()
        {
            Message("Pilih menu:");
            Message("1. Buat tempat parkir");
            Message("2. Parkir kendaraan");
            Message("3. Kendaraan Keluar");
            Message("4. Laporan Status Slot Parkir");
            Message("5. Laporan jumlah slot parkir yang terisi");
            Message("6. Laporan jumlah kendaraan berdasarkan nomor ganjil atau genap");
            Message("7. Laporan jumlah kendaraan berdasarkan jenis kendaraan");
            Message("8. Laporan jumlah kendaraan berdasarkan warna kendaraan");
            Message("0. Keluar");
        }

        public static void Message(string message)
        {
            System.Console.WriteLine(message);
        }

       public static int CalculateEntryFee(VehicleType vehicleType, List<Vehicle> parkedVehicles, Dictionary<VehicleType, int> entryFee)
        {
            // Hitung biaya masuk berdasarkan jenis kendaraan dan durasi parkir
            int baseFee = entryFee[vehicleType];
            int additionalFeePerHour = vehicleType == VehicleType.Motor ? 1000 : 2000;

            // Hitung jumlah jam parkir
            int totalHours = parkedVehicles.Count(v => v.VehicleType.ToString() == vehicleType.ToString());

            // Hitung total biaya masuk
            int totalFee = baseFee + additionalFeePerHour * (totalHours - 1); // Biaya untuk jam pertama sudah termasuk dalam baseFee

            return totalFee;
        }

        internal static int CalculateEntryFee(string v, List<Vehicle> parkedVehicles, Dictionary<VehicleType, int> entryFee)
        {
            throw new NotImplementedException();
        }

        private int CalculateTotalParkingHours(Vehicle vehicle)
        {
            // Ambil waktu masuk kendaraan dari properti DateEntered
            DateTime entryTime = vehicle.DateEntered;

            // Ambil waktu keluar saat ini
            DateTime exitTime = DateTime.Now;

            // Hitung selisih waktu antara waktu keluar dan waktu masuk dalam satuan jam
            TimeSpan parkingDuration = exitTime - entryTime;
            int totalHours = (int)Math.Ceiling(parkingDuration.TotalHours);

            // Pastikan total jam tidak kurang dari 1
            return Math.Max(totalHours, 1);
        }

        internal static int CalculateParkingFee(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}