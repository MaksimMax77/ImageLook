using UnityEngine;

namespace Windows
{
    public class WindowsManager : MonoBehaviour
    {
        [SerializeField] private LoadingWindow.LoadingWindow _loadingWindow;
        [SerializeField] private GameStartWindow.GameStartWindow _gameStartWindow;
        [SerializeField] private GalleryWindow.GalleryWindow _galleryWindow;
        [SerializeField] private ImageViewWindow.ImageViewWindow _imageViewWindow;
    
        public LoadingWindow.LoadingWindow LoadingWindow => _loadingWindow;
        public GameStartWindow.GameStartWindow GameStartWindow => _gameStartWindow;
        public GalleryWindow.GalleryWindow GalleryWindow => _galleryWindow;
        public ImageViewWindow.ImageViewWindow ImageViewWindow => _imageViewWindow;
    }
}
