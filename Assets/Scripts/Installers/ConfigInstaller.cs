using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private ClockConfig _clockConfig;
        public override void InstallBindings()
        {
            BindClockConfig();
        }

        private void BindClockConfig()
        {
            Container.Bind<ClockConfig>()
                .FromScriptableObject(_clockConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}