using System;
using Cysharp.Threading.Tasks;
using Models.DownloadedJson;
using Models.Time;
using Presenters.TimeRequest;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using Utils;
using Views.UI.SynchronizeButton;

namespace Presenters.UI.SynchronizeButton
{
    public class SynchronizeButtonPresenter
    {
        private readonly Button _button;
        private readonly TMP_Text _buttonText;
        private readonly string _startButtonText;
        private readonly DownloadedJsonModel _jsonModel;
        private readonly TimeRequestService _timeRequestService;


        public SynchronizeButtonPresenter(TimeRequestService timeRequestService, Button button, TMP_Text buttonText, DownloadedJsonModel jsonModel)
        {
            InvariantChecker.CheckObjectInvariant<SynchronizeButtonPresenter>(timeRequestService, button, buttonText, jsonModel);

            _timeRequestService = timeRequestService;
            _button = button;
            _buttonText = buttonText;
            _jsonModel = jsonModel;
            _startButtonText = _buttonText.text;
        }

        public void Enable()
        {
            SynchronizeTime().Forget();
            _button.onClick.AddListener(() => SynchronizeTime().Forget());
        }

        public void Disable()
        {
            _button.onClick.RemoveListener(() => SynchronizeTime().Forget());
        }

        private async UniTaskVoid SynchronizeTime()
        {
            SetLoadingVisual();
            string json = await _timeRequestService.RequestTimeJson();
            if (json == String.Empty)
                await SetErrorVisual();
            _jsonModel.SetJson(json);
            RestoreVisual();
        }
        

        private void SetLoadingVisual()
        {
            UniTask.Void(async () =>
            {
                await UniTask.SwitchToMainThread();
                _button.interactable = false;
                _buttonText.text = "Synchronizing...";
            });
        }

        private async UniTask SetErrorVisual()
        {
            _buttonText.text = "Connection error";
            await UniTask.Delay((int) (1000 * 2));
        }

        private void RestoreVisual()
        {
            UniTask.Void(async () =>
            {
                await UniTask.SwitchToMainThread();
                _button.interactable = true;
                _buttonText.text = _startButtonText;
            });
        }
    }
}