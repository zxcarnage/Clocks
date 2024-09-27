using System;
using Models.DownloadedJson;
using Models.Time;
using Presenters.TimeRequest;
using Presenters.UI.SynchronizeButton;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views.UI.SynchronizeButton
{
    [RequireComponent(typeof(Button))]
    public class SynchronizeButtonView : MonoBehaviour
    {
        private SynchronizeButtonPresenter _presenter;

        private string _previousText;

        [Inject]
        public void Initialize(TimeRequestService timeRequestService, Button button, TMP_Text buttonText, DownloadedJsonModel downloadedJsonModel)
        {
            _presenter = new(timeRequestService,button,buttonText, downloadedJsonModel);
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