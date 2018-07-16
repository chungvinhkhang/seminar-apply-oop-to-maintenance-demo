using System;
using System.Collections.Generic;
using Lyd.MoopDemo.PmsCore;

namespace Lyd.MoopDemo.PmsConsole
{
    public class PmsConsoleApp
    {
        private PmsApp pmsApp;

        public PmsConsoleApp()
        {
            pmsApp = new PmsApp();
            this.Run();
        }

        private void Run()
        {
            pmsApp.InitGuests();
            this.ShowMenuScreen();
        }

        private void ShowMenuScreen()
        {
            Console.Clear();
            Console.WriteLine("PHAN MEM QUAN LY KHACH SAN");
            Console.WriteLine("1. Quan ly ho so khach");
            Console.WriteLine("2. Quan ly don dat phong");
            Console.WriteLine("3. Quan ly checkin/checkout");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ShowManageGuestProfilesScreen();
                    break;
                case 2:
                    //TODO
                    ShowMenuScreen();
                    break;
                case 3:
                    //TODO
                    ShowMenuScreen();
                    break;
                case 0:
                    Console.WriteLine("Cam on va hen gap lai!");
                    break;
                default:
                    ShowMenuScreen();
                    break;
            }
        }

        private void ShowManageGuestProfilesScreen()
        {
            List<Guest> guests = pmsApp.GetGuests();
            Console.Clear();
            Console.WriteLine($"QUAN LY HO SO KHACH\nMa\tTen");
            ShowGuests(guests);

            Console.WriteLine("1. Tim kiem ho so khach");
            Console.WriteLine("2. Them ho so khach moi");
            Console.WriteLine("0. Quay lai");
            Console.Write("Chon: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ShowSearchGuestsScreen();
                    break;
                case 2:
                    ShowCreateGuestScreen();
                    break;
                case 0:
                    ShowMenuScreen();
                    break;
                default:
                    ShowManageGuestProfilesScreen();
                    break;
            }
        }

        private void ShowSearchGuestsScreen()
        {
            Console.Clear();
            Console.WriteLine($"TIM KIEM HO SO KHACH");
            Console.Write("Nhap ten: ");
            string name = Console.ReadLine();
            List<Guest> guests = pmsApp.SearchGuest(new SearchOption(name));

            if (guests.Count == 0)
            {
                Console.WriteLine("Khong co ket qua.");
                Console.WriteLine("1. Tiep tuc tim kiem");
                Console.WriteLine("0. Quay lai");
                Console.Write("Chon: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ShowSearchGuestsScreen();
                        break;
                    case 0:
                        ShowManageGuestProfilesScreen();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                ShowGuests(guests);
                Console.Read();
                ShowManageGuestProfilesScreen();
            }

           
        }

        private void ShowCreateGuestScreen()
        {
            Console.Clear();
            Console.WriteLine($"THEM HO SO KHACH");
            Console.Write("Nhap ten: ");
            string name = Console.ReadLine();

            Console.Write("Nhap so dien thoai: ");
            string phone = Console.ReadLine();

            Console.Write("Nhap dia chi: ");
            string address = Console.ReadLine();

            Console.Write("Nhap gioi tinh (Nam: M, Nu: F):");
            string genderText = Console.ReadLine();
            Gender gender = genderText == "M" ? Gender.Male : Gender.Female;

            var createdGuest = pmsApp.CreateGuest(name, address, phone, gender);
            Console.WriteLine($"Da them thanh cong. Ma khach : {createdGuest.GuestCode}");
            Console.Read();
            this.ShowManageGuestProfilesScreen();
        }

        private void ShowGuests(List<Guest> guests)
        {
            foreach (var guest in guests)
            {
                Console.WriteLine($"{guest.GuestCode}\t{guest.GuestName}");
            }
        }





    }
}
