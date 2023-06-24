using UnityEngine;

namespace Sources.Windows
{
    public class WindowsManager : MonoBehaviour
    {
        [SerializeField] private LoadingWindow _loadingWindow;
        [SerializeField] private GameStartWindow _gameStartWindow;
        [SerializeField] private GalleryWindow _galleryWindow;
        [SerializeField] private ImageViewWindow _imageViewWindow;
    
        public LoadingWindow LoadingWindow => _loadingWindow;
        public GameStartWindow GameStartWindow => _gameStartWindow;
        public GalleryWindow GalleryWindow => _galleryWindow;
        public ImageViewWindow ImageViewWindow => _imageViewWindow;
    }
}
