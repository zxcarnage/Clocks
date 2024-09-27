using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Models.DownloadedJson;
using Models.Time;
using Utils;

namespace Presenters.DateTimeIncreaser
{
    public class DateTimeIncreaserService : IDisposable
    {
        private readonly DownloadedJsonModel _jsonModel;
        private readonly TimeModel _timeModel;

        private CancellationTokenSource _cts;

        public DateTimeIncreaserService(DownloadedJsonModel jsonModel, TimeModel timeModel)
        {
            InvariantChecker.CheckObjectInvariant<DateTimeIncreaserService>(jsonModel,timeModel);

            _jsonModel = jsonModel;
            _timeModel = timeModel;

            _jsonModel.NewDataDownloaded += OnNewDataDownloaded;
        }

        private void OnNewDataDownloaded()
        {
            if (_cts != null)
            {
                _cts.Cancel();
                _cts.Dispose();
            }

            _cts = new CancellationTokenSource();
            IncreaseDateTime(_cts.Token).Forget();
        }

        private async UniTask IncreaseDateTime(CancellationToken token)
        {
            while(true)
                try
                {
                    await UniTask.Delay(1000, cancellationToken: token);
                    _timeModel.SynchronizeTime(_timeModel.Time.AddSeconds(1));
                }
                catch (OperationCanceledException)
                {
                    break;
                }
        }

        public void Dispose()
        {
            _jsonModel.NewDataDownloaded -= OnNewDataDownloaded;
        }
    }
}