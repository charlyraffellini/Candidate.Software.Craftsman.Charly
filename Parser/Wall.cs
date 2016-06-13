using System;
using System.Collections.Generic;
using Model;

namespace Parser
{
    public class Wall : PostPrinter
    {
        protected override Func<User, IEnumerable<Post>> PostGetter => (u) => u.AggregatePosts;

        public Wall(string person) : base(person) { }
    }
}