using System.Collections.Generic;
using FSM.States;

namespace FSM
{
    public class StatesStack
    {
        private Stack<State> _states = new Stack<State>();

        public void PushState(State state)
        {
            _states.Push(state);
        }
        
        public State PopState()
        {
            return _states.Pop();
        }
    }
}
