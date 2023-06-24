using Sources.FSM;
using Sources.FSM.States;
using Sources.Gallery;
using Sources.System.Input;
using Sources.System.Update;
using Sources.Windows;
using UnityEngine;
using Zenject;

namespace Sources.Installers
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField] private WindowsManager _windowsManager;
        [SerializeField] private UpdateManager _updateManager;

        public override void InstallBindings()
        {
            Container.Bind<UpdateManager>().FromInstance(_updateManager).AsSingle().NonLazy();
            Container.Bind<InputControl>().AsSingle().NonLazy();
            Container.Bind<WindowsManager>().FromInstance(_windowsManager).AsSingle().NonLazy();
            Container.Bind<SelectedTexture>().AsSingle().NonLazy();
            InstallSceneStateMachine();
        }

        private void InstallSceneStateMachine()
        {
            Container.Bind<LoadState>().AsSingle().NonLazy();
            Container.Bind<StartGameState>().AsSingle().NonLazy();
            Container.Bind<GalleryState>().AsSingle().NonLazy();
            Container.Bind<ImageViewState>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SceneStateMachine>().AsSingle().NonLazy();
        }
    }
}