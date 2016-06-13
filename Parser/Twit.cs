using Model;

namespace Parser
{
    public class Twit : TwitterCommand
    {
        public string Message { get; set; }

        public Twit(string person, string message) : base(person)
        {
            Message = message;
        }

        public override void Run(TwitterContext twitterContext)
        {
            var person = this.GetPerson(twitterContext);
            person.AddPost(new Post(this.Message));
        }
    }
}