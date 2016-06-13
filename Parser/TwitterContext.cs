using Konsole;

namespace Parser
{
    public class TwitterContext
    {
        public TwitterContext(IConsole console)
        {
            this.PeopleHome = new PeopleHome();
            this.Console = console;
        }

        public IConsole Console { get; set; }

        public PeopleHome PeopleHome { get; set; }
    }
}