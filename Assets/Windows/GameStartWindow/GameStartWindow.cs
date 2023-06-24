using System;
using UnityEngine;

namespace Windows.GameStartWindow
{
    public class GameStartWindow : MonoBehaviour
    {
        public event Action ButtonClicked;
    
        public void OnStartButtonClick()
        {
            ButtonClicked?.Invoke();
        }
    }
}
