using System;
using RosMessageTypes.BuiltinInterfaces;

namespace Unity.Robotics.Core
{
    public readonly struct TimeStamp
    {
        public const double k_NanosecondsInSecond = 1e9f;

        public readonly int Seconds;
        public readonly uint NanoSeconds;

        public TimeStamp(double timeInSeconds)
        {
            var sec = Math.Floor(timeInSeconds);
            var nsec = (timeInSeconds - sec) * k_NanosecondsInSecond;
            Seconds = (int)sec;
            NanoSeconds = (uint)nsec;
        }

        TimeStamp(int sec, uint nsec)
        {
            Seconds = sec;
            NanoSeconds = nsec;
        }

        public static implicit operator TimeMsg(TimeStamp stamp)
        {
            return new TimeMsg(stamp.Seconds, stamp.NanoSeconds);
        }

        public static implicit operator TimeStamp(TimeMsg stamp)
        {
            return new TimeStamp(stamp.sec, stamp.nanosec);
        }
    }
}
