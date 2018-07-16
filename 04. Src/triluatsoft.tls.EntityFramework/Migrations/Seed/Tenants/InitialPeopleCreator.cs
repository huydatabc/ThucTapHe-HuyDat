using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Domain.Chat;
using triluatsoft.tls.EntityFramework;

namespace triluatsoft.tls.Migrations.Seed.Tenants
{
    public class InitialPeopleCreator
    {
        private readonly tlsDbContext _context;

        public InitialPeopleCreator(tlsDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var douglas = _context.Persons.FirstOrDefault(p => p.EmailAddress == "douglas.adams@fortytwo.com");
            if (douglas == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Douglas",
                        Surname = "Adams",
                        EmailAddress = "douglas.adams@fortytwo.com"
                    });
                _context.SaveChanges();
            }

            var asimov = _context.Persons.FirstOrDefault(p => p.EmailAddress == "isaac.asimov@foundation.org");
            if (asimov == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Isaac",
                        Surname = "Asimov",
                        EmailAddress = "isaac.asimov@foundation.org"
                    });
                _context.SaveChanges();
            }
        }
    }
}
