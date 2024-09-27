using DG.Tweening;
using Dummies;
using Models.Time;
using ScriptableObjects;
using UnityEngine;
using Utils;

namespace Presenters.UI.Clocks
{
    public class ClocksPresenter
    {
        private readonly TimeModel _timeModel;
        private readonly HourHand _hourHand;
        private readonly MinuteHand _minuteHand;
        private readonly SecondHand _secondHand;
        private readonly ClockConfig _clockConfig;

        public ClocksPresenter(TimeModel timeModel, ClockConfig clockConfig, HourHand hourHand, MinuteHand minuteHand, SecondHand secondHand)
        {
           InvariantChecker.CheckObjectInvariant<ClocksPresenter>(timeModel, hourHand, minuteHand, secondHand,clockConfig);
            
            _timeModel = timeModel;
            _minuteHand = minuteHand;
            _hourHand = hourHand;
            _secondHand = secondHand;
            _clockConfig = clockConfig;
        }

        public void Enable()
        {
            _timeModel.TimeUpdated += OnTimeUpdated;
        }

        private void OnTimeUpdated()
        {
            Debug.Log(_timeModel.Time);
            
            float secondHandAngle = _timeModel.Time.Second * 6f;
            float minuteHandAngle = _timeModel.Time.Minute * 6f + _timeModel.Time.Second * 0.1f;
            float hourHandAngle = (_timeModel.Time.Hour % 12) * 30f + _timeModel.Time.Minute * 0.5f;

            RotateHand(_secondHand, secondHandAngle);
            RotateHand(_minuteHand, minuteHandAngle);
            RotateHand(_hourHand, hourHandAngle);
        }

        private void RotateHand(Hand targetHand, float targetAngle)
        {
            targetHand.transform.DORotate(new Vector3(0, 0, -targetAngle), _clockConfig.AnimationDuration);
        }

        public void Disable()
        {
            _timeModel.TimeUpdated -= OnTimeUpdated;
        }
    }
}