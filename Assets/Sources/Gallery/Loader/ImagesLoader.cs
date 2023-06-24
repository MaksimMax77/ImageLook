using System;
using System.Threading.Tasks;
using Sources.Gallery.Container;
using Sources.Windows;
using UnityEngine;
using UnityEngine.Networking;
using Object = UnityEngine.Object;

namespace Sources.Gallery.Loader
{
    public class ImagesLoader: IDisposable
    {
        private string _url;
        private ImageContainer _imageContainerPrefab;
        private int _amountImages;
        private Transform _imagesParent;
        private Action<Texture> _changeState;
        private ImageContainersClickHandler _imageContainersClickHandler;
    
        public ImagesLoader(ImagesLoaderSettings imagesLoaderSettings, GalleryWindow galleryWindow, Action<Texture> changeState)
        {
            _url = imagesLoaderSettings.URL;
            _amountImages = imagesLoaderSettings.AmountImages;
            _imageContainerPrefab = imagesLoaderSettings.ImageContainer;
            _imagesParent = galleryWindow.ContentTransform;
            _changeState = changeState;
            _imageContainersClickHandler = new ImageContainersClickHandler();
            _imageContainersClickHandler.ImageClicked += OnImageClick;
        }

        private void OnImageClick(Texture texture)
        {
            _changeState?.Invoke(texture);
        }

        public async void CreateImages()
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
                _imageContainersClickHandler.Add(obj);
                obj.SetTexture(texture);
            }
        }
        
        public void Dispose()
        {
            _imageContainersClickHandler.ImageClicked -= OnImageClick;
            _imageContainersClickHandler?.Dispose();
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
