using Sources.Gallery.Container;
using UnityEngine;

namespace Sources.Gallery.Loader
{
    [CreateAssetMenu(fileName = "ImagesLoaderSettings2", menuName = "ImagesLoader Settings2", order = 51)]
    public class ImagesLoaderSettings : ScriptableObject
    {
        [SerializeField] private string _url = "http://data.ikppbb.com/test-task-unity-data/pics/";
        [SerializeField] private int _amountImages = 66;
        [SerializeField] private ImageContainer _imageContainer;

        public string URL => _url;
        public int AmountImages => _amountImages;
        public ImageContainer ImageContainer => _imageContainer;
    }
}
