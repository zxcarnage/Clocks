using System;
using Models.Time;
using Presenters.UI.Clocks.TimeText;
using TMPro;
using UnityEngine;
using Zenject;

namespace Views.UI.Clocks.TimeText
{
    public class TimeTextView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        private TimeTextPresenter _presenter;
        
        [Inject]
        public void Initialize(TimeModel timeModel)
        {
            _presenter = new(timeModel, _text);
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