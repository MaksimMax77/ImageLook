using UnityEngine;

namespace Sources.Gallery
{
    public class SelectedTexture
    {
        private Texture _texture;
        public Texture Texture => _texture;

        public void SetTexture(Texture texture)
        {
            _texture = texture;
        }
    }
}
