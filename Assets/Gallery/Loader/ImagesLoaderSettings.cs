using Gallery.Container;
using UnityEngine;

namespace Gallery.Loader
{
    [CreateAssetMenu(fileName = "ImagesLoaderSettings2", menuName = "ImagesLoader Settings2", order = 51)]
    public class ImagesLoaderSettings : ScriptableObject
    {
        [SerializeField] private string _url = "http://data.ikppbb.com/test-task-unity-data/pics/";
        [SerializeField] private ImageContainer imageContainerPrefab;
        [SerializeField] private int _amountImages = 66;

        public string URL => _url;
        public ImageContainer ImageContainerPrefab => imageContainerPrefab;
        public int AmountImages => _amountImages;
    }
}
