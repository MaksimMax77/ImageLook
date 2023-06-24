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
        }

        private void OnSceneLoad(Scene scene, LoadSceneMode mode)
        {
            var window = Object.Instantiate(_windowsManager.ImageViewWindow);
            window.SetTexture(_selectedTexture.Texture);
        }
    }
}
