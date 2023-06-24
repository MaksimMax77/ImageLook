using UnityEngine;

namespace Sources.Windows
{
    public class GalleryWindow : MonoBehaviour
    {
        [SerializeField] private Transform _contentTransform;
        public Transform ContentTransform => _contentTransform;
    }
}
