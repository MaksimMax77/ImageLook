using System.Update;
using UnityEngine;
using Zenject;

namespace System.Input
{
    public class InputControl: IUpdate
    {
        public event Action EscapeClicked;
        
        [Inject]
        public void Init(UpdateManager updateManager)
        {
            updateManager.AddUpdate(this);
        }
        public void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                EscapeClicked?.Invoke();
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.A))//test
            {
                EscapeClicked?.Invoke();
            }
        }
    }
}
