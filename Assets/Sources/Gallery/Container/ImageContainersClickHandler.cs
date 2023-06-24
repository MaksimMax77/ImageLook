using System;
using System.Collections.Generic;
using Sources.FSM;
using Sources.FSM.States;
using UnityEngine;
using Zenject;

namespace Sources.Gallery.Container
{
    public class ImageContainersClickHandler : IDisposable
    {
        private List<ImageContainer> _imageContainers = new List<ImageContainer>();
        private SelectedTexture _selectedTexture;
        private SceneStateMachine _sceneStateMachine;

        [Inject]
        public void Init(SelectedTexture selectedTexture, SceneStateMachine sceneStateMachine)
        {
            _selectedTexture = selectedTexture;
            _sceneStateMachine = sceneStateMachine;
        }
        public void Add(ImageContainer container)
        {
            _imageContainers.Add(container);
            container.Clicked += OnImageClick;
        }

        public void Dispose()
        {
            for (int i = 0, len = _imageContainers.Count; i < len; ++i)
            {
                _imageContainers[i].Clicked -= OnImageClick;
            }
        }

        private void OnImageClick(Texture texture)
        {
            _selectedTexture.SetTexture(texture);
            _sceneStateMachine.EnterInState(typeof(LoadState), typeof(ImageViewState));
        }
    }
}

