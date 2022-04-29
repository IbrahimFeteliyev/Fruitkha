using Entities;

namespace Web.ViewModels
{
    public class AboutVM
    {
        public List<Service> Services { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Company> Companies { get; set; }
        public List<OurTeam> OurTeams { get; set; }

    }
}
