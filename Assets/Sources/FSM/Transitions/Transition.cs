using System;

namespace Sources.FSM.Transitions
{
    public abstract class Transition
    { 
        protected Action _startNextState;
        public virtual void Execute(Action startNextState)
        {
            _startNextState = startNextState;
        }
    }
}
