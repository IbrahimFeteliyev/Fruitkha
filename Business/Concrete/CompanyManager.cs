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
    public class CompanyManager : ICompanyManager
    {
        private readonly FruitkhaDbContext _context;

        public CompanyManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Company company)
        {
            company.PublishDate = DateTime.Now;
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public void Delete(Company company)
        {
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }

        public void Edit(Company company)
        {
            company.UpdateDate = DateTime.Now;
            _context.Companies.Update(company);
            _context.SaveChanges();
        }

        public List<Company> GetAll()
        {
            var company = _context.Companies.ToList();
            return company;
        }

        public Company GetById(int id)
        {
            var company = _context.Companies.FirstOrDefault(x => x.ID == id);
            return company;
        }
    }
}
