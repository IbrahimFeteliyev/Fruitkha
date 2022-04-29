using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOurTeamManager
    {
        List<OurTeam> GetAll();
        OurTeam GetById(int id);
        void Create(OurTeam ourteam);
        void Edit(OurTeam ourteam);
        void Delete(OurTeam ourteam);
    }
}
