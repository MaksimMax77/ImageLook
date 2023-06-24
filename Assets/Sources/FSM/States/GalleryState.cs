using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.FSM.States
{
    public class GalleryState : State
    {
        public override void OnEnter()
        {
            Screen.orientation = ScreenOrientation.Portrait;
            SceneManager.LoadScene(2);
        }
        public override void OnExit()
        {
        }
    }
}
