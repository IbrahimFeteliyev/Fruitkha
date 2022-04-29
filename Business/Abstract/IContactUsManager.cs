using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactUsManager
    {
        List<ContactUs> GetAll();
        ContactUs GetById(int id);
        void Delete(ContactUs contactus);
        void PostMessage(ContactUs contactus);

    }
}
