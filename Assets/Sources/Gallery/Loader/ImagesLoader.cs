using System.Threading.Tasks;
using Sources.Gallery.Container;
using Sources.Windows;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace Sources.Gallery.Loader
{
    public class ImagesLoader
    {
        private string _url;
        private ImageContainer _imageContainerPrefab;
        private int _amountImages;
        private Transform _imagesParent;
        private ImageContainersClickHandler _imagesEventSubscriber;

        [Inject]
        public void Init(GalleryWindow galleryWindow, ImagesLoaderSettings imagesLoaderSettings,
            ImageContainersClickHandler imagesEventSubscriber, ImageContainer imageContainer)
        {
            _imageContainerPrefab = imageContainer;
            _url = imagesLoaderSettings.URL;
            _amountImages = imagesLoaderSettings.AmountImages;
            _imagesParent = galleryWindow.ContentTransform;
            _imagesEventSubscriber = imagesEventSubscriber;
            CreateImages();
        }

        private async void CreateImages()
        {
            for (var i = 0; i < _amountImages; ++i)
            {
                var imageIndex = i + 1;
                var texture = await GetRemoteTexture(_url, imageIndex);
                if (_imagesParent == null)
                {
                    return;
                }
                var obj = Object.Instantiate(_imageContainerPrefab, _imagesParent);
                _imagesEventSubscriber.Add(obj);
                obj.SetTexture(texture);
            }
        }

        private static async Task<Texture2D> GetRemoteTexture(string url, int index)
        {
            using var www = UnityWebRequestTexture.GetTexture(url + index + ".jpg");
            var asyncOp = www.SendWebRequest();

            while (asyncOp.isDone == false)
            {
                await Task.Delay(1000 / 30);
            }

            if (www.isNetworkError || www.isHttpError)
            {
                return null;
            }

            return DownloadHandlerTexture.GetContent(www);
        }
    }
}
 
