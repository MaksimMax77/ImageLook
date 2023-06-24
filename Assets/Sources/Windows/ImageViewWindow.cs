using System;
using JetBrains.Annotations;
using Sources.Gallery;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sources.Windows
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
