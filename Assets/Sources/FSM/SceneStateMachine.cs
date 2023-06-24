using System;
using System.Collections.Generic;
using Sources.FSM.States;
using Sources.System.Input;
using Zenject;

namespace Sources.FSM
{
    public class SceneStateMachine : IDisposable
    {
        private List<State> _states2;
        private State _currentState;
        private InputControl _inputControl;
        
        [Inject]
        public void Init(LoadState loadState, StartGameState startGameState,
            GalleryState galleryState, ImageViewState imageViewState, InputControl inputControl)
        {
            _states2 = new List<State>()
            {
                loadState,
                startGameState,
                galleryState,
                imageViewState
            };

            _inputControl = inputControl;
            SetStateMachine();
            _inputControl.EscapeClicked += OnEscapeClicked;
            EnterInState(typeof(StartGameState));
        }
        
        public void EnterInState(Type stateType, Type nextStateType = null) 
        {
            var state = GetStateByType(stateType);

            if (state == null)
            {
                return;
            }
            
            state.SetNextState(nextStateType);
            _currentState?.OnExit();
            _currentState = state;
            _currentState.OnEnter();
        }
        
        public void Dispose()
        {
            _inputControl.EscapeClicked -= OnEscapeClicked;
        }
        private void SetStateMachine()
        {
            for (int i = 0, len = _states2.Count; i < len; ++i)
            {
                _states2[i].SetStateMachine(this);
            }
        }
        
        private void OnEscapeClicked()
        {
            var index = _states2.IndexOf(_currentState);
            --index;
            
            if (index <= 0)
            {
                return;
            }
            
            var state = _states2[index];
            EnterInState(typeof(LoadState), state.GetType());
        }

        private State GetStateByType(Type type)
        {
            State state = null;
            
            for (int i = 0, len = _states2.Count; i < len; ++i)
            {
                if (type == _states2[i].GetType())
                {
                    state = _states2[i];
                }
            }

            return state;
        }
    }
}
