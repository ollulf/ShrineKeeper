using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Core
{
    [SingletonSettings(SingletonLifetime.Scene, _canBeGenerated: true, _eager: false)]
    public class TimeHandler : SingletonBehaviour<TimeHandler>
    {
        public Time CurrentTime;
        public bool TimePaused = false;        
        protected override void Awake()
        {
            base.Awake();
            GameInstance.Current.CoroutineService.RunCoroutine(InitializeTime());
        }
        public class Time
        {
            public int Day;
            public int Hour;
            public int Minute;

            public const int HoursPerDay = 24;

            public const int MinutesPerHour = 60;

            public const float MinuteDurationInRealSeconds = 0.3f;
            public Time(int day, int hour, int minute)
            {
                Day = day;
                Hour = hour;
                Minute = minute;
            }

            public float TimeOfDayAs24Float => Hour + ((float)Minute / MinutesPerHour);
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

            for (var i = 0; i < Time.HoursPerDay; i++)
            {
                currentMinute = 0;
                for (int j = 0; j < Time.MinutesPerHour; j++)
                {
                    yield return new WaitForSeconds(Time.MinuteDurationInRealSeconds);
                    //Minute Passed
                    currentMinute++;

                    CurrentTime.Day = CurrentDay;
                    CurrentTime.Hour = currentHour;
                    CurrentTime.Minute = currentMinute;

                }
                currentHour++;
            }
        }
        private void OnGUI()
        {
            GUILayout.Label($"Current Time: {CurrentTime.Hour.ToString("00")}:{CurrentTime.Minute.ToString("00")}");
        }
    }
}
