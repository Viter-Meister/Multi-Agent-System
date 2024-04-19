using System;
using UnityEngine;

namespace Unity.Robotics.Core
{
    public static class Clock
    {
        public enum ClockMode
        {
            UnityScaled,
            RosScaled
        }

        public const double k_NanoSecondsInSeconds = 1e9;

        static readonly DateTime k_UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        static readonly double k_StartTimeEpochSeconds = SecondsSinceUnixEpoch - Time.realtimeSinceStartupAsDouble;
        
        static double SecondsSinceUnixEpoch => (DateTime.Now - k_UnixEpoch).TotalSeconds;
        static double UnityUnscaledTimeSinceFrameStart => 
            Time.realtimeSinceStartupAsDouble - Time.unscaledTimeAsDouble;

        public static double TimeSinceFrameStart => Now - FrameStartTimeInSeconds;

        public static double FrameStartTimeInSeconds
        {
            get
            {
                return Mode switch
                {
                    ClockMode.UnityScaled => Time.timeAsDouble,
                    _ => throw new NotImplementedException()
                };
            }
        }

        public static double NowTimeInSeconds
        {
            get
            {
                return Mode switch
                {
                    ClockMode.UnityScaled => Time.timeAsDouble + UnityUnscaledTimeSinceFrameStart * Time.timeScale,
                    _ => throw new NotImplementedException()
                };
            }
        }
        
        public static float DeltaTimeInSeconds
        {
            get
            {
                return Mode switch
                {
                    ClockMode.UnityScaled => Time.deltaTime,
                    _ => Time.unscaledDeltaTime,
                };
            }
        }

        public static ClockMode Mode = ClockMode.UnityScaled;

        public static double Now => NowTimeInSeconds;
        public static double time => FrameStartTimeInSeconds;
        public static float deltaTime => DeltaTimeInSeconds;

        public static double GetFrameTime(ClockMode temporaryMode)
        {
            var originalMode = Mode;
            Mode = temporaryMode;
            var t = FrameStartTimeInSeconds;
            Mode = originalMode;
            return t;
        }

        public static double GetNowTime(ClockMode temporaryMode)
        {
            var originalMode = Mode;
            Mode = temporaryMode;
            var t = NowTimeInSeconds;
            Mode = originalMode;
            return t;
        }
    }
}