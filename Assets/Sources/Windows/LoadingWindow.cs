using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Windows
{
    public class LoadingWindow : MonoBehaviour
    {
        public event Action Loaded;
        [SerializeField] private Image _image;
        [SerializeField] private Text _text;
        [SerializeField] private float _speed;
    
        private void Update()
        {
            if (!(_image.fillAmount < 1f))
            {
                Loaded?.Invoke();
                return;
            }
            _image.fillAmount +=_speed * Time.deltaTime;
            _text.text = GetPercent() + " %";
        }

        private float GetPercent()
        {
            return _image.fillAmount / 1 * 100;
        }

        private void OnDestroy()
        {
            _image.fillAmount = 0.0f;
        }
    }
}
