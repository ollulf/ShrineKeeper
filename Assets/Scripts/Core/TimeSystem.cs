using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class TimeSystem
    {
        private TimeSystemConfig mConfig;

        public Time CurrentTime;
        public bool TimePaused = false;
        public class Time
        {
            public int Day;
            public int Hour;
            public int Minute;
            public Time(int day, int hour, int minute)
            {
                Day = day;
                Hour = hour;
                Minute = minute;
            }
        }
        public TimeSystem(TimeSystemConfig config)
        {
            mConfig = config;
            GameInstance.Current.CoroutineService.RunCoroutine(InitializeTime());
        }

        IEnumerator InitializeTime()
        {
            var day = 1;
            CurrentTime = new Time(day, 0, 0);
            while (!TimePaused)
            {

                yield return RunDay(day);
                day++;

                if (day >= 20)
                {
                    TimePaused = true;
                }
            }
        }

        IEnumerator RunDay(int CurrentDay)
        {
            var currentHour = 0;
            int currentMinute;

            for (var i = 0; i < mConfig.HoursPerDay; i++)
            {
                currentMinute = 0;
                for (int j = 0; j < mConfig.MinutesPerHour; j++)
                {
                    yield return new WaitForSeconds(mConfig.SecondsPerMinute);
                    //Minute Passed
                    currentMinute++;

                    CurrentTime.Day = CurrentDay;
                    CurrentTime.Hour = currentHour;
                    CurrentTime.Minute = currentMinute;

                    Debug.Log($"Day: {CurrentTime.Day} || Time: {CurrentTime.Hour}:{CurrentTime.Minute}");
                }

                //HourPassed
                currentHour++;
            }
            //DayPassed
        }
    }

}
