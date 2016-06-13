using System.Linq;
using Sprache;

namespace Parser
{
    public static class Grammar
    {
        public static readonly Parser<string> IdentifierParser =
            from leading in Parse.WhiteSpace.Many()
            from first in Parse.Letter.Once()
            from rest in Parse.LetterOrDigit.Many()
            from trailing in Parse.WhiteSpace.Many()
            select new string(first.Concat(rest).ToArray());

        public static readonly Parser<Twit> TweetParser =
            from person in IdentifierParser.Token()
            from arrow in Parse.String("->").Token()
            from message in Parse.AnyChar.Many().Text()
            select new Twit(person, message);

        public static readonly Parser<Follow> FollowParser =
            from person in IdentifierParser.Token()
            from verb in Parse.String("follows").Token()
            from personFollowed in IdentifierParser.Token()
            select new Follow(person, personFollowed);

        public static readonly Parser<Wall> WallParser =
            from person in IdentifierParser.Token()
            from verb in Parse.String("wall").Token()
            select new Wall(person);

        public static readonly Parser<NewPerson> NewPersonParser =
            from verb in Parse.String("new").Token()
            from person in IdentifierParser.Token()
            select new NewPerson(person);

        public static readonly Parser<TimeLine> TimeLineParser =
            from person in IdentifierParser.Token()
            select new TimeLine(person);



        public static readonly Parser<TwitterCommand> CommandParser =
            (TweetParser as Parser<TwitterCommand>)
            .Or(FollowParser)
            .Or(WallParser)
            .Or(NewPersonParser)
            .Or(TimeLineParser);
    }
}
