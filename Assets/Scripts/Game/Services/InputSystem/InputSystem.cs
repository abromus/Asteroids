using Asteroids.Core.Settings;
using Asteroids.Inputs;
using UnityEngine;

namespace Asteroids.Game.Services
{
    public sealed class InputSystem : UiService, IInputSystem
    {
        [SerializeField] private GameObject _editorView;
        [SerializeField] private GameObject _defaultView;

        private Transform _parent;
        private PlayerInputActions _playerInputActions;
        private GameObject _view;

        public override UiServiceType UiServiceType => UiServiceType.InputSystem;

#if UNITY_EDITOR
        public PlayerInputActions.KeyboardActions InputActions => _playerInputActions.Keyboard;
#else
        public PlayerInputActions.JoystickActions InputActions  => _playerInputActions.Joystick;
#endif

        public void Init(Transform parent)
        {
            _parent = parent;

            _playerInputActions = new PlayerInputActions();
        }

        public void Destroy()
        {
            Hide();
        }

        public void Show()
        {
            var prefab = _defaultView;

#if UNITY_EDITOR
            prefab = _editorView;
#endif

            if (_view == null && prefab != null)
                _view = Instantiate(prefab, _parent);
        }

        public void Hide()
        {
            if (_view != null)
                Destroy(_view);
        }
    }
}
