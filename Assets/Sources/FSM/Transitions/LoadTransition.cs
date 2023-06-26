using System;
using Sources.Windows;
using UnityEngine.SceneManagement;
using Zenject;
using Object = UnityEngine.Object;


namespace Sources.FSM.Transitions
{
    public class LoadTransition: Transition
    {
        private LoadingWindow _loadingWindow;
        private WindowsManager _windowsManager;
        
        [Inject]
        public void Init(WindowsManager windowsManager)
        {
            _windowsManager = windowsManager;
        }
        public override void Execute(Action startNextState)
        {
            SceneManager.LoadScene(0);
            SceneManager.sceneLoaded += OnSceneLoad;
            base.Execute(startNextState);
        }
        
        private void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            _loadingWindow = Object.Instantiate(_windowsManager.LoadingWindow);
            _loadingWindow.Loaded += OnLoaded;
        }

        private void OnLoaded()
        {
            _loadingWindow.Loaded -= OnLoaded;
            SceneManager.sceneLoaded -= OnSceneLoad;
            _startNextState?.Invoke();
        }
    }
}
