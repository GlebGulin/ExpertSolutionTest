using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

using System.Collections.Specialized;



namespace Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Companyname { get; set; }
        public IEnumerable<Guest> Guests;
    }
}
