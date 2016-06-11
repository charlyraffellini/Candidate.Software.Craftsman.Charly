using System;
using Utils.Test;

namespace Utils.Time
{
    public abstract class TimeProvider
    {
        private static TimeProvider instance = new DefaultTimeProvider();

        public static TimeProvider Instance
        {
            get { return instance; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ups... something was wrong, you can not set a null value here");
                }
                instance = value;
            }
        }
        public abstract DateTime Now { get; }
        public abstract DateTime Today { get; }
    }
}