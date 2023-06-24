using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Gallery.Container
{
     public class ImageContainer : MonoBehaviour
     {
          public event Action<Texture> Clicked; 
          [SerializeField] private RawImage _image;

          public void SetTexture(Texture2D texture)
          {
               _image.texture = texture;
          }

          [UsedImplicitly]
          public void OnButtonClick()
          {
               Clicked?.Invoke(_image.texture);
          }
     }
}
