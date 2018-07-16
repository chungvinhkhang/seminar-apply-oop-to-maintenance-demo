using System;
using System.Collections.Generic;
using System.Linq;

namespace Lyd.MoopDemo.PmsCore
{
    public class PmsApp
    {

        private List<Guest> _guests;
        private IGuestCodeGenerator _guestCodeGenerator;

        public PmsApp()
        {
            _guests = new List<Guest>();
            _guestCodeGenerator = new GuestCodeGenerator();
        }


        public List<Guest> InitGuests()
        {
            this._guests.Clear();
            CreateGuest("Chung Vinh Khang", "97 Vo Van Tan", "01227155908", Gender.Male);
            CreateGuest("Bui Cao Tu", "114 Dinh Tien Hoang", "01227155911", Gender.Male);
            CreateGuest("Vu Hoai Nam", "68/8 Ngo Tat To", "01227155308", Gender.Male);
            CreateGuest("Nguyen Duy Phuong", "14 Doan Van Bo", "01227155108", Gender.Male);
            return this._guests;
        }

        public List<Guest> GetGuests()
        {
            return this._guests;
        }

        public List<Guest> SearchGuest(SearchOption searchOption)
        {
            List<Guest> result = _guests.Where(p => p.GuestName.Contains(searchOption.GuestName)).ToList();
            return result;
        }

        public Guest CreateGuest(string guestName, string address, string phone, Gender? gender)
        {
            var newGuest = new Guest(guestName, address, phone, gender);
            newGuest.GenerateGuestCode(_guestCodeGenerator);
            this._guests.Add(newGuest);
            return newGuest;
        }
    }
}
