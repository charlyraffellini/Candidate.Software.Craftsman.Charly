using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class User
    {
        public User(string name)
        {
            this.Name = name;
            this.Posts = new List<Post>();
            this.PeopleWhoFollow = new List<User>();
        }

        public string Name { get; private set; }

        public void AddPost(Post post)
        {
            post.Owner = this;
            this.Posts.Add(post);
        }

        public ICollection<Post> Posts { get; private set; }

        public void Follow(User anotherUser)
        {
            this.PeopleWhoFollow.Add(anotherUser);
        }

        public ICollection<User> WhoIFollow => PeopleWhoFollow;

        private ICollection<User> PeopleWhoFollow { get; }

        public IEnumerable<Post> AggregatePosts => PeopleWhoFollow
            .SelectMany(u => u.Posts)
            .Concat(this.Posts)
            .OrderBy(p => p.SecondsSinceCreation);
    }
}