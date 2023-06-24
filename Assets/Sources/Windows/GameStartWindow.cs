using System;
using UnityEngine;

namespace Sources.Windows
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
