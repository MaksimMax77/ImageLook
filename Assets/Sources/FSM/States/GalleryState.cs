using Sources.Gallery;
using Sources.Gallery.Loader;
using Sources.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Sources.FSM.States
{
    public class GalleryState : State
    {
        private WindowsManager _windowsManager;
        private ImagesLoader _imagesLoader;
        private SelectedTexture _selectedTexture;
        
        private ImagesLoaderSettings _imagesLoaderSettings;
        
        [Inject]
        public void Init(WindowsManager windowsManager, SelectedTexture selectedTexture, ImagesLoaderSettings imagesLoaderSettings)
        {
            _windowsManager = windowsManager;
            _selectedTexture = selectedTexture;
            _imagesLoaderSettings = imagesLoaderSettings;
        }
        public override void OnEnter()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            SceneManager.LoadScene(2);
            SceneManager.sceneLoaded += OnSceneLoad;
        }
        
        public override void OnExit()
        {
            SceneManager.sceneLoaded -= OnSceneLoad;
            _imagesLoader.Dispose();
        }
        
        private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
        {
           var window = Object.Instantiate(_windowsManager.GalleryWindow);
           _imagesLoader = new ImagesLoader(_imagesLoaderSettings, window, SetTextureSetImageViewState);
           _imagesLoader.CreateImages();
        }

        private void SetTextureSetImageViewState(Texture texture)
        {
            _selectedTexture.SetTexture(texture);
            _sceneStateMachine.EnterInState(typeof(LoadState), typeof(ImageViewState));
        }
    }
}
