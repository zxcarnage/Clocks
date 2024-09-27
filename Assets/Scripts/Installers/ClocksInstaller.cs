using Dummies;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ClocksInstaller : MonoInstaller
    {
        [SerializeField] private HourHand _hourHand;
        [SerializeField] private MinuteHand _minuteHand;
        [SerializeField] private SecondHand _secondHand;

        public override void InstallBindings()
        {
            BindHourHand();
            BindMinuteHand();
            BindSecondHand();
        }

        private void BindSecondHand()
        {
            Container.Bind<SecondHand>()
                .FromInstance(_secondHand)
                .AsSingle()
                .NonLazy();
        }

        private void BindMinuteHand()
        {
            Container.Bind<MinuteHand>()
                .FromInstance(_minuteHand)
                .AsSingle()
                .NonLazy();
        }

        private void BindHourHand()
        {
            Container.Bind<HourHand>()
                .FromInstance(_hourHand)
                .AsSingle()
                .NonLazy();
        }
    }
}