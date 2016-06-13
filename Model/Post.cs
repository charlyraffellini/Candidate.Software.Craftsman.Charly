using System;
using Utils.Time;

namespace Model
{
    public class Post
    {
        public Post(string content)
        {
            this.Content = content;
            this.CreationDate = TimeProvider.Instance.Now;
        }

        public User Owner { get; set; }
        public DateTime CreationDate { get; set; }

        public string Content { get; set; }
        public TimeSpan TimeSinceCreation => TimeProvider.Instance.Now.Subtract(CreationDate);
        public int MinutesSinceCreation => (int)this.TimeSinceCreation.TotalMinutes;
        public int SecondsSinceCreation => (int)this.TimeSinceCreation.TotalSeconds;
    }
}