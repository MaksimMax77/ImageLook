using UnityEngine;

namespace Windows.GalleryWindow
{
    public class GalleryWindow : MonoBehaviour
    {
        [SerializeField] private Transform _contentTransform;
        public Transform ContentTransform => _contentTransform;
    }
}
