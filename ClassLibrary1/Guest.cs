using System;

namespace Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
    }
}
