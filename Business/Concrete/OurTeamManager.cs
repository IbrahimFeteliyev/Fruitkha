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
    public class OurTeamManager : IOurTeamManager
    {
        private readonly FruitkhaDbContext _context;

        public OurTeamManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(OurTeam ourteam)
        {
            ourteam.PublishDate = DateTime.Now;
            _context.OurTeams.Add(ourteam);
            _context.SaveChanges();

        }

        public void Delete(OurTeam ourteam)
        {
            _context.OurTeams.Remove(ourteam);
            _context.SaveChanges();
        }

        public void Edit(OurTeam ourteam)
        {
           ourteam.UpdateDate = DateTime.Now;
            _context.OurTeams.Update(ourteam);
            _context.SaveChanges();
        }

        public List<OurTeam> GetAll()
        {
            var ourteam = _context.OurTeams.ToList();
            return ourteam;

        }

        public OurTeam GetById(int id)
        {
            var ourteam = _context.OurTeams.FirstOrDefault(x => x.ID == id);
            return ourteam;
        }
    }
}
