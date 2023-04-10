using BLL;
using Models;
using System;
using System.Linq;
using System.Collections.Generic;
using DTOs;

namespace Companies
{
    class Program
    {
        static void Main(string[] args)
        {
            IQueryResult query          = new QueryResult();
            var companyQuery            = query.GetCompanies();
            var guestQuery              = query.GetGuests();
            List<Guest> expertSolutions = new List<Guest>();
            Console.WriteLine("Companies: ");
            foreach (var company in companyQuery)
            {
                Console.WriteLine("Id: " + company.CompanyId +", Company Name: " + company.Companyname);
            }
            Console.WriteLine();

            Console.WriteLine("Guests: ");
            foreach (var guest in guestQuery)
            {
                Console.WriteLine("Id: " + guest.GuestId + ", Name: " + guest.Name);
            }

            //Гості, які живуть від компанії ExpertSolution
            
            var expertSolution = companyQuery.Where(x => x.Companyname.Equals("ExpertSolution")).FirstOrDefault();
            if (expertSolution is not null)
                expertSolutions = guestQuery.Where(y => y.CompanyId == expertSolution.CompanyId).ToList();

            Console.WriteLine();
            if (expertSolutions.Count > 0)
            {
                Console.WriteLine("Гостi, якi живуть вiд компанii ExpertSolution: ");
                foreach (var expertWorker in expertSolutions)
                {
                    Console.WriteLine("Працiвник: " + expertWorker.Name);
                }
            }

            Console.WriteLine();
            //Усі компанії із зазначенням кількості людей, які живуть від них, відсортованих за зменшенням кількості гостей.
            Console.WriteLine("Усі компанii iз зазначенням кiлькостi людей, якi живуть вiд них, відсортованих за зменшенням кількості гостей: ");
            var compCountWorkers =
                (from comp in companyQuery
                select new
                {
                    Name = comp.Companyname,
                    Count = guestQuery.Where(emp => emp.CompanyId == comp.CompanyId).Count()
                }).OrderByDescending(x => x.Count);

            foreach (var c in compCountWorkers)
                Console.WriteLine("Компанiя: " + c.Name + " , кiлькiсть працiвникiв: " + c.Count);

            Console.WriteLine();

            //15.1.3.	Усі компанії, для яких є гості з прізвищем, що закінчується на "ко". У результат вивести список таких компаній, без даних гостя
            var coWorkers = from p in companyQuery
                join c in guestQuery on p.CompanyId equals c.CompanyId where c.Name.EndsWith("ко")
                select new { Name = p.Companyname };

            Console.WriteLine("Усi компанiї, для яких є гості з прiзвищем, що закiнчується на 'ко'. У результат вивести список таких компанiй, без даних гостя: ");
            foreach (var coWorker in coWorkers)
                Console.WriteLine("Назва компанiї: " + coWorker.Name);

            Console.WriteLine();

            //Усі компанії та гостей, які проживають від них. У результаті має виводитися назва компанії, список імен гостей через кому. Для виведення результату використовувати клас CompanyDTO3
            List<CompanyDTO3> companiesExpended = new List<CompanyDTO3>();
            foreach (var c in companyQuery)
            {
                CompanyDTO3 compExpended = new CompanyDTO3();
                var GuestNames           = new List<string>();
                compExpended.CompanyName = c.Companyname;
                compExpended.CompanyID   = c.CompanyId;
                var workerExpended = guestQuery.Where(x => x.CompanyId == c.CompanyId).ToList();
                foreach (var w in workerExpended)
                {
                    GuestNames.Add(w.Name);
                }
                compExpended.GuestNames = string.Join(", ", GuestNames);
                Console.WriteLine("Назва компанiї: " + compExpended.CompanyName + ", Гостi: " + compExpended.GuestNames);
                companiesExpended.Add(compExpended);
            }

            Console.ReadKey();
        }
    }
}
