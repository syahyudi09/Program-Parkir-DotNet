using System;
using ProgramParkir.ParkingManagement;

class Program
{
    static void Main(string[] args)
    {
        ParkingManager parkingManager = new ParkingManager(0);

        while (true)
        {
            Util.Menu();
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // untuk membuar slot parking
                    parkingManager.CreateParkingLot();
                    break;
                case "2":
                    // untuk input kendaraan yanng akan parkir
                    Console.WriteLine("Masukkan informasi kendaraan (nomor registrasi warna jenis):");
                    string inputVehicle = Console.ReadLine();
                    string[] vehicleInfo = inputVehicle.Split(' ');

                    if (vehicleInfo.Length != 3)
                    {
                        Util.Message("Format informasi kendaraan tidak valid. Pastikan Anda memasukkan nomor registrasi, warna, dan jenis kendaraan yang dipisahkan oleh spasi.");
                        break;
                    }

                    string registrationNumber = vehicleInfo[0];
                    string color = vehicleInfo[1];
                    string typeString = vehicleInfo[2];

                    if (!Enum.TryParse(typeString, true, out VehicleType type))
                    {
                        Util.Message("Pilihan jenis kendaraan tidak valid.");
                        break;
                    }

                    parkingManager.ParkVehicle(registrationNumber, color, type.ToString());
                    break;
                case "3":
                    // untuk kendaraan keluar
                    Console.WriteLine("Masukkan Slot yang Keluar:");
                    int slotNumber;
                    if (!int.TryParse(Console.ReadLine(), out slotNumber))
                    {
                        Util.Message("Slot yang dimasukkan tidak valid. Pastikan Anda memasukkan nomor slot yang benar.");
                        break;
                    }
                    parkingManager.LeaveSlot(slotNumber);
                    break;
                case "4":
                    // untuk mengecek status slot parkir
                     parkingManager.CheckingParkingStatus();
                     break;
                case "5":
                    // untuk menghitung jumlah slot yang tersedia
                     parkingManager.GetOccupiedSlots();
                     break;
                case "6":
                    // untuk menghitung jumlah slot yang tersedia
                     parkingManager.GetAvaliableSlot();
                     break;
                case "7":
                    // untuk mengecek kendaraan berdasarkan plat nomor
                    parkingManager.CountVehiclesByOddCount();
                    break;
                case "8":
                    // untuk mengecek kendaraan berdasarkan plat nomor
                    parkingManager.CountVehiclesByEvenCount();
                    break;
                case "9":
                    // untuk mengeceka kendaraan berdasarkan type
                    parkingManager.CountVehiclesByType();
                    break;
                case "10":
                    // untuk mengecek kendaraan berdasarkan warna kendaraan
                    parkingManager.CountVehiclesByColor();
                    break;
                 case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Util.Message("Silahkan Pilih Menu");
                    break;
            }
        }
    }
}
