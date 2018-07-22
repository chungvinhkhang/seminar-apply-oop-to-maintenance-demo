using System;
namespace Lyd.MoopDemo.PmsCore
{
    public class Guest
    {
        public string GuestCode
        {
            get;
            private set;
        }

        public string GuestName
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }

        public Gender? Gender
        {
            get;
            set;
        }

        public Guest(string guestName, string address, string phone, Gender? gender)
        {
            this.GuestName = guestName;
            this.Address = address;
            this.Phone = phone;
            this.Gender = gender;
        }

        public string GenerateGuestCode(IGuestCodeGenerator generator)
        {
            this.GuestCode = generator.Generate(this);
            return this.GuestCode;
        }
    }
}
