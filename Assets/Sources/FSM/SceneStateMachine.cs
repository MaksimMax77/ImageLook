using System;
using System.Collections.Generic;
using Sources.FSM.States;
using Sources.FSM.Transitions;
using Sources.System.Input;
using Zenject;

namespace Sources.FSM
{
    public class SceneStateMachine : IDisposable
    {
        private List<State> _states;
        private State _currentState;
        private InputControl _inputControl;
        
        [Inject]
        public void Init(LoadTransition loadTransition, StartGameState startGameState,
            GalleryState galleryState, ImageViewState imageViewState, InputControl inputControl)
        {
            _states = new List<State>()
            {
                startGameState,
                galleryState,
                imageViewState
            };

            for (int i = 0, len = _states.Count; i < len; ++i)
            {
                _states[i].SetTransition(loadTransition);
            }
            
            _inputControl = inputControl;
            SetStateMachine();
            _inputControl.EscapeClicked += OnEscapeClicked;
            EnterInState(typeof(StartGameState));
        }
        
        public void EnterInState(Type stateType) 
        {
            var state = GetStateByType(stateType);

            if (state == null)
            {
                return;
            }
            
            _currentState?.OnExit();
            _currentState = state;
            _currentState.Transition.Execute(() =>
            {
                _currentState.OnEnter();
            });
        }
        
        public void Dispose()
        {
            _inputControl.EscapeClicked -= OnEscapeClicked;
        }
        private void SetStateMachine()
        {
            for (int i = 0, len = _states.Count; i < len; ++i)
            {
                _states[i].SetStateMachine(this);
            }
        }
        
        public void OnEscapeClicked()
        {
            var index = _states.IndexOf(_currentState);
            --index;
            
            if (index < 0)
            {
                return;
            }
            
            var state = _states[index];
            EnterInState(state.GetType());
        }
        
        private State GetStateByType(Type type)
        {
            State state = null;
            
            for (int i = 0, len = _states.Count; i < len; ++i)
            {
                if (type == _states[i].GetType())
                {
                    state = _states[i];
                }
            }
            return state;
        }
    }
}
