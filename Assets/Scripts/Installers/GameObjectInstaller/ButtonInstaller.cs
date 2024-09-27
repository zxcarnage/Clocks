using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Installers.GameObjectInstaller
{
    public class ButtonInstaller : MonoInstaller<ButtonInstaller>
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _buttonText;

        public override void InstallBindings()
        {
            BindButton();
            BindButtonText();
        }

        private void BindButtonText()
        {
            Container.Bind<TMP_Text>()
                .FromInstance(_buttonText)
                .AsSingle()
                .NonLazy();
        }

        private void BindButton()
        {
            Container.Bind<Button>()
                .FromInstance(_button)
                .AsSingle()
                .NonLazy();
        }
    }
}