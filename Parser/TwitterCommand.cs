using System.Collections.Generic;
using System.Linq;
using Konsole;
using Model;

namespace Parser
{
    public abstract class TwitterCommand
    {
        protected TwitterCommand(string person)
        {
            Person = person;
        }

        public abstract void Run(TwitterContext twitterContext);

        public string Person { get; }

        protected User GetPerson(TwitterContext twitterContext)
        {
            return GetPerson(twitterContext, this.Person);
        }

        protected User GetPerson(TwitterContext twitterContext, string person)
        {
            return twitterContext.PeopleHome.GetPerson(person);
        }
    }
}