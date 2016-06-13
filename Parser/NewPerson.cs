using Model;

namespace Parser
{
    public class NewPerson : TwitterCommand
    {
        public NewPerson(string person) : base(person) { }

        public override void Run(TwitterContext twitterContext)
        {
            twitterContext.PeopleHome.AddPerson(new User(this.Person));
        }
    }
}