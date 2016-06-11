using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Test;
using Utils.Time;
using Xunit;

namespace Model.Test
{
    public class UserTest
    {
        private User Charly { get; set; }
        private User Marco { get; set; }

        public UserTest()
        {
            TimeProvider.Instance = new TestTimeProvider();
            this.Marco = new User("Marco");
            this.Charly = new User("Charly");
            this.Marco.Follow(Charly);
        }

        [Fact]
        public void Marco_can_publish_in_his_personal_timeline()
        {
            var marcoPost = new Post("Do you guys want to get together today/evening?");
            Marco.AddPost(marcoPost);
            Marco.Posts.ShouldBeEquivalentTo(new List<Post>{ marcoPost });
        }

        [Fact]
        public void Marco_can_follow_Charly()
        {
            Marco.PeopleWhoFollow.ShouldBeEquivalentTo(new List<User>{Charly});
        }

        [Fact, FreezeClock]
        public void An_user_can_view_an_aggregate_list_of_all_subscriptions()
        {
            var marcoPost = CreatePostInExplicitTime("Marco Post", 0);
            var firstCharlyPost = CreatePostInExplicitTime("First Charly Post", 500);
            var seconCharlyPost = CreatePostInExplicitTime("Second Charly Post", 1000);
            Marco.AddPost(marcoPost);
            Charly.AddPost(firstCharlyPost);
            Charly.AddPost(seconCharlyPost);

            Marco.AggregatePosts.ToArray().ShouldBeEquivalentTo(new [] {seconCharlyPost, firstCharlyPost, marcoPost});
            Marco.AggregatePosts.Should().BeInAscendingOrder(p => p.SecondsSinceCreation);
        }

        [Fact]
        public void Get_aggregated_post_have_not_effect_over_own_post_collection()
        {
            Charly.AddPost(new Post("aPost"));

            Marco.AggregatePosts.Should().HaveCount(1);
            Marco.Posts.Should().BeNullOrEmpty();
        }

        public static Post CreatePostInExplicitTime(string content, int seconds)
        {
            Clock.FreezeUtc(Clock.UtcNow.AddSeconds(seconds));
            return new Post(content);
        }
    }
}
