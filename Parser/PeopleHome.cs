using System.Collections.Generic;
using System.Linq;
using Model;

namespace Parser
{
    public class PeopleHome
    {
        public PeopleHome()
        {
            this.People = new List<User>();
        }

        public User GetPerson(string name) => this.People.First(p => p.Name == name);
        public void AddPerson(User user) => this.People.Add(user);

        private List<User> People { get; set; }
    }
}