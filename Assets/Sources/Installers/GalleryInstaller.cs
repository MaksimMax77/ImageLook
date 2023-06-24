using Sources.Gallery.Container;
using Sources.Gallery.Loader;
using Sources.Windows;
using UnityEngine;
using Zenject;

namespace Sources.Installers
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