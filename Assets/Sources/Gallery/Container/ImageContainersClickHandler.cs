using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Gallery.Container
{
    public class ImageContainersClickHandler: IDisposable
    {
        public event Action<Texture> ImageClicked;
        private List<ImageContainer> _imageContainers = new List<ImageContainer>();

        public void Add(ImageContainer container)
        {
            _imageContainers.Add(container);
            container.Clicked += OnImageClick;
        }
        public void Dispose()
        {
            for (int i = 0, len = _imageContainers.Count; i < len; ++i)
            {
                _imageContainers[i].Clicked -= OnImageClick;
            }
        }
        private void OnImageClick(Texture texture)
        {
            ImageClicked?.Invoke(texture);
        }
    }
}
