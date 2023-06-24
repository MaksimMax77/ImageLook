using System;
using Gallery;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Windows.ImageViewWindow
{
    public class ImageViewWindow : MonoBehaviour
    {
        public event Action BackClicked;
        [SerializeField] private RawImage _rawImage;

        [Inject]
        public void Init(SelectedTexture selectedTexture)
        {
            _rawImage.texture = selectedTexture.Texture;
        }
        
        public void SetTexture(Texture texture)
        {
            _rawImage.texture = texture;
        }

        [UsedImplicitly]
        public void OnBackClick()
        {
            BackClicked?.Invoke();
        }
    }
}
