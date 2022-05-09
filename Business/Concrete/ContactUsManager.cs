using Business.Abstract;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactUsManager : IContactUsManager
    {
        private readonly FruitkhaDbContext _context;

        public ContactUsManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Delete(ContactUs contactus)
        {
            _context.ContactUss.Remove(contactus);
            _context.SaveChanges();
        }


        public List<ContactUs> GetAll()
        {
            var contactus = _context.ContactUss.ToList();
            return contactus;
        }

        public ContactUs GetById(int id)
        {
            var contactus = _context.ContactUss.FirstOrDefault(x => x.ID == id);
            return contactus;
        }

        public void PostMessage(ContactUs contactus)
        {
            contactus.PublishDate = DateTime.Now;
            _context.ContactUss.Add(contactus);
            _context.SaveChanges();
        }
    }
}
