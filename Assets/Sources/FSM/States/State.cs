using Sources.FSM.Transitions;

namespace Sources.FSM.States
{
    public abstract class State
    {
        protected SceneStateMachine _sceneStateMachine;
        private Transition _transition;
        public Transition Transition => _transition;

        public void SetTransition(Transition transition)
        {
            _transition = transition;
        }
        public void SetStateMachine(SceneStateMachine stateMachine)
        {
            _sceneStateMachine = stateMachine;
        }
        public abstract void OnEnter();

        public abstract void OnExit();
    }
}
