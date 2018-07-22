using System;
namespace Lyd.MoopDemo.PmsCore
{
    public class SearchOption
    {
        public string GuestName
        {
            get;
            set;
        }

        public SearchOption(string guestName)
        {
            this.GuestName = guestName;
        }
    }
}
