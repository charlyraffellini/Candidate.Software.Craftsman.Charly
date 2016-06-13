using System.Collections.Generic;
using System.Linq;
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

        protected void PrintPosts(TwitterContext twitterContext, IEnumerable<Post> posts)
        {
            posts.ToList()
                .ForEach(p => twitterContext.Console.WriteLine(p.Content + " (" + p.MinutesSinceCreation + " minutes)"));
        }

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