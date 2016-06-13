using System;
using System.Collections.Generic;
using Model;

namespace Parser
{
    public class TimeLine : PostPrinter
    {
        protected override Func<User, IEnumerable<Post>> PostGetter => (u) => u.Posts;
        public TimeLine(string person) : base(person) { }
    }
}