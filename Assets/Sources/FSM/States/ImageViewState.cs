using Sources.Gallery;
using Sources.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Sources.FSM.States
{
    public class ImageViewState : State
    {
        private WindowsManager _windowsManager;
        private SelectedTexture _selectedTexture;
        private ImageViewWindow _imageViewWindow;
        
        [Inject]
        public void Init(WindowsManager windowsManager, SelectedTexture selectedTexture)
        {
            _windowsManager = windowsManager;
            _selectedTexture = selectedTexture;
        }
        public override void OnEnter()
        {
            Screen.orientation = ScreenOrientation.AutoRotation;
            SceneManager.LoadScene(3);
            SceneManager.sceneLoaded += OnSceneLoad;
        }
        public override void OnExit()
        {
            SceneManager.sceneLoaded -= OnSceneLoad;
            _imageViewWindow.BackClicked -= _sceneStateMachine.OnEscapeClicked;
        }

        private void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            _imageViewWindow = Object.Instantiate(_windowsManager.ImageViewWindow);
            _imageViewWindow.SetTexture(_selectedTexture.Texture);
            _imageViewWindow.BackClicked += _sceneStateMachine.OnEscapeClicked;
        }
    }
}
