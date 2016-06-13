using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace Parser
{
    public abstract class PostPrinter : TwitterCommand
    {
        protected abstract Func<User,IEnumerable<Post>> PostGetter { get; }
        public override void Run(TwitterContext twitterContext)
        {
            var person = GetPerson(twitterContext);
            PrintPosts(twitterContext, PostGetter(person));
        }

        public PostPrinter(string person) : base(person) { }

        private void PrintPosts(TwitterContext twitterContext, IEnumerable<Post> posts)
        {
            posts.ToList().ForEach(p =>
            {
                twitterContext.Console.WriteLine(LineContent(p));
            });
        }

        protected virtual string LineContent(Post post) => $"{post.Content} ({this.TimeLabel(post)})";

        private string TimeLabel(Post post) => post.MinutesSinceCreation == 0 ? post.SecondsSinceCreation + " seconds" : post.MinutesSinceCreation + " minutes";
    }
}