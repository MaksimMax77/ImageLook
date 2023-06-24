using System;

namespace FSM.States
{
    public abstract class State
    {
        protected SceneStateMachine _sceneStateMachine;
        protected Type _nextStateType;
        public Type NextState => _nextStateType;
        public void SetStateMachine(SceneStateMachine stateMachine)
        {
            _sceneStateMachine = stateMachine;
        }
        public void SetNextState(Type nextStateType)
        {
            _nextStateType = nextStateType;
        }
        public abstract void OnEnter();

        public abstract void OnExit();
    }
}
