using Windows.GalleryWindow;
using Gallery.Container;
using Gallery.Loader;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GalleryInstaller : MonoInstaller
    {
        [SerializeField] private GalleryWindow _galleryWindow;
        [SerializeField] private ImagesLoaderSettings _settings;
        [SerializeField] private ImageContainer _imageContainer;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ImageContainersClickHandler>().AsSingle().NonLazy();
            Container.Bind<GalleryWindow>().FromInstance(_galleryWindow).AsSingle().NonLazy();
            Container.Bind<ImagesLoaderSettings>().FromInstance(_settings);
            Container.Bind<ImageContainer>().FromInstance(_imageContainer);
            Container.Bind<ImagesLoader>().AsSingle().NonLazy();
        }
    }
}