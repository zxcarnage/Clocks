using Dummies;
using Models.Time;
using Presenters.UI.Clocks;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Views.UI.Clocks
{
    public class ClocksView : MonoBehaviour
    {
        private ClocksPresenter _presenter;

        [Inject]
        public void Initialize(TimeModel timeModel, ClockConfig clockConfig, HourHand hourHand, MinuteHand minuteHand,
            SecondHand secondHand)
        {
            _presenter = new(timeModel, clockConfig, hourHand, minuteHand, secondHand);
        }

        private void OnEnable()
        {
            _presenter.Enable();
        }

        private void OnDisable()
        {
            _presenter.Disable();
        }
    }
}