using System;
using Cysharp.Threading.Tasks;
using Models.Time;
using UnityEngine.Networking;
using Utils;

namespace Presenters.TimeRequest
{
    public class TimeRequestService : IDisposable
    {
        private readonly TimeModel _timeModel;

        public TimeRequestService(TimeModel timeModel)
        {
            InvariantChecker.CheckObjectInvariant<TimeRequestService>(timeModel);

            _timeModel = timeModel;
            _timeModel.HourUpdated += OnHourUpdated;
        }


        public async UniTask<string> RequestTimeJson()
        {
            using UnityWebRequest request = UnityWebRequest.Get(_timeModel.GetURL);
            
            await request.SendWebRequest();
            
            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError
                or UnityWebRequest.Result.DataProcessingError)
                return String.Empty;
            
            return request.downloadHandler.text;
        }


        public void Dispose()
        {
            _timeModel.HourUpdated -= OnHourUpdated;
        }

        private void OnHourUpdated()
        {
            RequestTimeJson().Forget();
        }
    }
}