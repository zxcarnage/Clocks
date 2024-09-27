using System;

namespace Models.Time
{
    public class TimeModel
    {
        public TimeModel(string getURL)
        {
            Time = new DateTime();
            GetURL = getURL;
        }
        public DateTime Time { get; private set; }
        public event Action TimeUpdated;
        public event Action HourUpdated;
        public string GetURL { get; private set; }

        public void SynchronizeTime(DateTime newTime)
        {
            if(Time.Hour != newTime.Hour)
                HourUpdated?.Invoke();
            Time = newTime;
            TimeUpdated?.Invoke();
        }
    }
}