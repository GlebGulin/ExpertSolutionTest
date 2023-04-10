using Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    //Basic initialization with data.
    //It is assumed that here the data will be taken from the context of the database binding.
    public class QueryResult : IQueryResult
    {
        public IQueryable<Company> GetCompanies()
        {
            var companiyList = new List<Company>()
            {
                new Company
                {
                    CompanyId = 1,
                    Companyname = "ExpertSolution"
                },
                new Company
                {
                    CompanyId = 2,
                    Companyname = "ServioSoft"
                },
                new Company
                {
                    CompanyId = 3,
                    Companyname = "Apple"
                }
            };

            return companiyList.AsQueryable();
        }

        public IQueryable<Guest> GetGuests()
        {
            var guests = new List<Guest>() 
            { 
                new Guest()
                {
                    GuestId = 1,
                    CompanyId = 1,
                    Name = "Iван Василiв"
                },
                new Guest()
                {
                    GuestId = 2,
                    CompanyId = 1,
                    Name = "Петро Симонович"
                },
                new Guest()
                {
                    GuestId = 3,
                    CompanyId = 2,
                    Name = "Василь Пупкiн"
                },
                new Guest()
                {
                    GuestId = 4,
                    CompanyId = 3,
                    Name = "Сергiй Iванов"
                },
                new Guest()
                {
                    GuestId = 5,
                    CompanyId = 2,
                    Name = "Роман Пушко"
                },
                new Guest()
                {
                    GuestId = 6,
                    CompanyId = 1,
                    Name = "Станiслав Мотужко"
                },
                new Guest()
                {
                    GuestId = 7,
                    CompanyId = 0,
                    Name = "Рустам Алекжi"
                },
            };
            return guests.AsQueryable();
        }
    }
}
