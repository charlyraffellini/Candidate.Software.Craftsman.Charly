using System;
using System.Collections.Generic;
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
    }
}