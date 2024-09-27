using Models.DownloadedJson;
using Models.Time;
using Presenters.DateTimeIncreaser;
using Presenters.JsonToDateTimeParser;
using Presenters.TimeRequest;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private string _getTimeURL;

        public override void InstallBindings()
        {
            BindTimeModel();
            BindJsonModel();
            BindDateTimeIncreaserService();
            BindJsonToDateTimeService();
            BindTimeRequestService();
        }

        private void BindTimeRequestService()
        {
            Container.Bind<TimeRequestService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindDateTimeIncreaserService()
        {
            Container.Bind<DateTimeIncreaserService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindJsonToDateTimeService()
        {
            Container.Bind<JsonToDateTimeParserService>()
                .AsSingle()
                .NonLazy();
        }

        private void BindJsonModel()
        {
            Container.Bind<DownloadedJsonModel>()
                .AsSingle()
                .NonLazy();
        }

        private void BindTimeModel()
        {
            Container.Bind<TimeModel>()
                .FromInstance(new TimeModel(_getTimeURL))
                .AsSingle()
                .NonLazy();
        }
    }
}