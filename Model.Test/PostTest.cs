using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Utils.Test;
using Utils.Time;
using Xunit;

namespace Model.Test
{
    public class PostTest
    {
        public PostTest()
        {
            TimeProvider.Instance = new TestTimeProvider();
        }

        [Fact, FreezeClock]
        public void Minutes_from_creation_are_calculated_fine()
        {
            var post = new Post("a content");
            Clock.FreezeUtc(Clock.UtcNow.AddSeconds(125));

            post.MinutesSinceCreation.Should().Be(2);
        }
    }
}
