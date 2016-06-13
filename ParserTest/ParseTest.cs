using System.Linq;
using FluentAssertions;
using Konsole;
using Model;
using Parser;
using Sprache;
using Xunit;

namespace ParserTest
{

    //Alice -> I love the weather today
    //Charlie follows Alice
    //Charlie wall
    //Alice

    public class ParseTest
    {
        public ParseTest()
        {
            this.TestConsole = new TestConsole(45, 20);
            this.Context = new TwitterContext(TestConsole);

            this.Charlie = new User("Charlie");
            var marco = new User("Marco");
            Charlie.AddPost(new Post("this is my first post"));
            Charlie.AddPost(new Post("this is my second post"));
            marco.AddPost(new Post("marco's post"));
            Charlie.Follow(marco);

            Context.PeopleHome.AddPerson(Charlie);
            Context.PeopleHome.AddPerson(marco);
        }

        private User Charlie { get; set; }

        private TwitterContext Context { get; set; }
        private TestConsole TestConsole { get; set; }

        [Fact]
        public void To_add_message_should_be_parsed_right()
        {
            var result = Grammar.TweetParser.Parse("Marco -> this is my first message");
            result.Person.Should().Be("Marco");
            result.Message.Should().Be("this is my first message");
        }

        [Fact]
        public void To_add_message_should_be_parsed_right_also_with_special_characters()
        {
            var result = Grammar.TweetParser.Parse("Marco -> =~!@#$%^&*()_+{}|?><]\"\'");
            result.Person.Should().Be("Marco");
            result.Message.Should().Be("=~!@#$%^&*()_+{}|?><]\"\'");
        }

        [Fact]
        public void To_follow_should_be_parsed_right()
        {
            var result = Grammar.FollowParser.Parse("Charlie follows Alice");
            result.Person.Should().Be("Charlie");
            result.PersonFollowed.Should().Be("Alice");
        }

        [Fact]
        public void To_follow_should_be_parsed_right_and_it_dont_care_what_text_follows()
        {
            var result = Grammar.FollowParser.Parse("Charlie follows Alice @this doestn't matter");
            result.Person.Should().Be("Charlie");
            result.PersonFollowed.Should().Be("Alice");
        }

        [Fact]
        public void To_print_wall_text_should_be_parsed_right()
        {
            var result = Grammar.WallParser.Parse("Charlie wall");
            result.Should().BeOfType<Wall>();
            result.Person.Should().Be("Charlie");
        }

        [Fact]
        public void To_print_wall_text_should_be_parsed_right_and_it_dont_care_what_text_follows()
        {
            var result = Grammar.WallParser.Parse("Charlie wall #this doesn't matter");
            result.Should().BeOfType<Wall>();
            result.Person.Should().Be("Charlie");
        }

        [Fact]
        public void To_print_timeline_text_should_be_parsed_right()
        {
            var result = Grammar.TimeLineParser.Parse("Charlie");
            result.Should().BeOfType<TimeLine>();
            result.Person.Should().Be("Charlie");
        }

        [Fact]
        public void To_print_timeline_text_should_be_parsed_right_and_it_dont_care_what_text_follows()
        {
            var result = Grammar.TimeLineParser.Parse("Charlie %this doesn't matter");
            result.Should().BeOfType<TimeLine>();
            result.Person.Should().Be("Charlie");
        }

        [Fact]
        public void To_create_a_new_person_should_be_parsed_right()
        {
            var result = Grammar.NewPersonParser.Parse("new Noelia");
            result.Should().BeOfType<NewPerson>();
            result.Person.Should().Be("Noelia");
        }

        [Fact]
        public void To_print_timeline_text_should_be_executed_right()
        {
            var result = Grammar.CommandParser.Parse("Charlie");
            result.Run(this.Context);

            var expected = "this is my first post (0 seconds)            \r\nthis is my second post (0 seconds)           ";
            this.TestConsole.Buffer.Should().Be(expected);
        }

        [Fact]
        public void To_print_wall_text_should_be_executed_right()
        {
            var result = Grammar.CommandParser.Parse("Charlie wall");
            result.Run(this.Context);

            var expected = "Marco - marco's post (0 seconds)             \r\nCharlie - this is my first post (0 seconds)  \r\nCharlie - this is my second post (0 seconds) ";
            this.TestConsole.Buffer.Should().Be(expected);
        }

        [Fact]
        public void A_follow_text_should_be_executed_right()
        {
            var result = Grammar.CommandParser.Parse("Charlie follows Adeliana");
            this.Context.PeopleHome.AddPerson(new User("Adeliana"));
            result.Run(this.Context);
    
            this.Charlie.WhoIFollow.Should().Contain(u => u.Name == "Adeliana");
        }

        [Fact]
        public void A_message_text_should_be_executed_right()
        {
            var result = Grammar.CommandParser.Parse("Charlie -> I love the weather today");
            result.Run(this.Context);

            this.Charlie.Posts.Should().Contain(p => p.Content == "I love the weather today");
        }

        [Fact]
        public void Can_create_a_new_person_right()
        {
            const string noeliaName = "Noelia";
            var result = Grammar.CommandParser.Parse($"new {noeliaName}");
            result.Run(this.Context);

            this.Context.PeopleHome.GetPerson(noeliaName).Name.Should().Be(noeliaName);
        }
    }
}
