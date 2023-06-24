using Windows;
using Windows.LoadingWindow;
using UnityEngine.SceneManagement;
using Zenject;
using Object = UnityEngine.Object;

namespace FSM.States
{
    public class LoadState : State
    {
        private LoadingWindow _loadingWindow;
        private WindowsManager _windowsManager;
        
        [Inject]
        public void Init(WindowsManager windowsManager)
        {
            _windowsManager = windowsManager;
        }
        public override void OnEnter()
        {
            SceneManager.LoadScene(0);
            SceneManager.sceneLoaded += OnSceneLoad;
        }
    
        public override void OnExit()
        {
            _loadingWindow.Loaded -= OnLoaded;
            SceneManager.sceneLoaded -= OnSceneLoad;
        }

        private void OnLoaded()
        {
            _sceneStateMachine.EnterInState(_nextStateType);
        }
    
        private void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            _loadingWindow = Object.Instantiate(_windowsManager.LoadingWindow);
            _loadingWindow.Loaded += OnLoaded;
        }
    }
}
