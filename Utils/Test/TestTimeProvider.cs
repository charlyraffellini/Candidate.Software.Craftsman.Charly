using System;
using Utils.Time;

namespace Utils.Test
{
    public class TestTimeProvider : TimeProvider
    {
        public override DateTime Now { get { return Clock.Now; } }
        public override DateTime Today { get { return Clock.Today; } }
    }
}