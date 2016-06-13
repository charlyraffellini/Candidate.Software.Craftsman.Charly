namespace Parser
{
    public class Follow : TwitterCommand
    {
        public string PersonFollowed { get; set; }

        public Follow(string person, string personFollowed) : base(person)
        {
            PersonFollowed = personFollowed;
        }

        public override void Run(TwitterContext twitterContext)
        {
            var person = GetPerson(twitterContext);
            var personFolloed = GetPerson(twitterContext, this.PersonFollowed);
            person.Follow(personFolloed);
        }
    }
}