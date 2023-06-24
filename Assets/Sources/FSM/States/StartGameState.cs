using Sources.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Sources.FSM.States
{
    public class StartGameState: State
    {
        private GameStartWindow _createdWindow;
        private WindowsManager _windowsManager;
        
        [Inject]
        public void Init(WindowsManager windowsManager)
        {
            _windowsManager = windowsManager;
        }
        public override void OnEnter()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            SceneManager.LoadScene(1);
            SceneManager.sceneLoaded += OnSceneLoad;
        }
    
        public override void OnExit()
        {
            _createdWindow.ButtonClicked -= OnGameStarted;
            SceneManager.sceneLoaded -= OnSceneLoad;
        }

        private void OnGameStarted()
        {
            _sceneStateMachine.EnterInState(typeof(LoadState),typeof(GalleryState));
        }

        private void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            _createdWindow = Object.Instantiate(_windowsManager.GameStartWindow);
            _createdWindow.ButtonClicked += OnGameStarted;
        }
    }
}
