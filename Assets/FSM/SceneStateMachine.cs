using System;
using System.Collections.Generic;
using System.Input;
using FSM.States;
using UnityEngine;
using Zenject;

namespace FSM
{
    public class SceneStateMachine : IDisposable
    {
        private Dictionary<Type, State> _states;
        private List<State> _states2;//
        private State _currentState;
        private StatesStack _statesStack;
        private InputControl _inputControl;
        
        [Inject]
        public void Init(LoadState loadState, StartGameState startGameState,
            GalleryState galleryState, ImageViewState imageViewState, InputControl inputControl)
        {
            _states = new Dictionary<Type, State>()
            {
                [typeof(LoadState)] = loadState,
                [typeof(StartGameState)] = startGameState,
                [typeof(GalleryState)] = galleryState,
                [typeof(ImageViewState)] = imageViewState
            };
            
            _states2 = new List<State>()//
            {
                loadState,
                startGameState,
                galleryState,
                imageViewState
            };//
            
            _inputControl = inputControl;
            SetStateMachine();
            _statesStack = new StatesStack();
            _inputControl.EscapeClicked += OnEscapeClicked; 
            
            EnterInState(typeof(StartGameState));
        }
        
        public void EnterInState(Type stateType, Type nextStateType = null) 
        {
            if (!_states.TryGetValue(stateType, out var state))
            {
                return;
            }
            
            if (_currentState != null && _currentState.GetType() != typeof(LoadState))
            {
                _statesStack.PushState(_currentState);
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
            var states = new List<State>();
            states.AddRange(_states.Values);
            for (int i = 0, len = states.Count; i < len; ++i)
            {
                states[i].SetStateMachine(this);
            }
        }
        
        private void OnEscapeClicked()
        {
            var state = _statesStack.PopState();
            EnterInState(state.GetType());
        }
    }
}
