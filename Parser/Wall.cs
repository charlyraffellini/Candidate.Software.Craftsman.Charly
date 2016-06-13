using System;
using System.Collections.Generic;
using Model;

namespace Parser
{
    public class Wall : PostPrinter
    {
        protected override Func<User, IEnumerable<Post>> PostGetter => (u) => u.AggregatePosts;

        public Wall(string person) : base(person) { }

        protected override string LineContent(Post post) => $"{post.Owner.Name} - {base.LineContent(post)}";
    }
}