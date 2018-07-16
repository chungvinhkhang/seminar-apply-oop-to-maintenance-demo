using System;
using System.Linq;

namespace Lyd.MoopDemo.PmsCore
{
    public class GuestCodeGenerator : IGuestCodeGenerator
    {
        public GuestCodeGenerator()
        {
        }

        public string Generate(Guest guest)
        {
            string firstCharOfGuestLastName = guest.GuestName.Substring(guest.GuestName.LastIndexOf(' ') + 1, 1);
            string threeLastCharOfGuestPhone = guest.Phone.Substring(guest.Phone.Length - 3);
            string code = $"{firstCharOfGuestLastName}{threeLastCharOfGuestPhone}";
            return code;
        }
    }
}
