using UnityEngine;
using UnityEngine.Scripting;
using EcsRunner.Helpers;
using EcsRunner.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Unity.Ugui;

namespace EcsRunner.Systems
{
    class ButtonInputSystem : EcsUguiCallbackSystem
    {
        private readonly EcsFilterInject<Inc<InputCompanent>> _filter = default;
        private readonly EcsPoolInject<InputCompanent> _inputPool = default;

        private bool _isButtonDown;
        private bool _isLeftPointerDown;
        private bool _isRightPointerDown;
        private bool _isStrafeEnd;


        public override void Run(IEcsSystems ecsSystems)
        {
            base.Run(ecsSystems);

            if (_isButtonDown)
            {
                if (_isLeftPointerDown)
                {
                    foreach (var entity in _filter.Value)
                    {
                        ref InputCompanent playerInputComponent = ref _inputPool.Value.Get(entity);
                        playerInputComponent.Direction = new Vector3(-1f, 0f, 0f);
                    }
                }
                if (_isRightPointerDown)
                {
                    foreach (var entity in _filter.Value)
                    {
                        ref InputCompanent playerInputComponent = ref _inputPool.Value.Get(entity);
                        playerInputComponent.Direction = new Vector3(1f, 0f, 0f);
                    }
                }
            }
            else if (!_isButtonDown && !_isStrafeEnd)
            {
                _isStrafeEnd = true;
                foreach (var entity in _filter.Value)
                {
                    ref InputCompanent playerInputComponent = ref _inputPool.Value.Get(entity);
                    playerInputComponent.Direction = new Vector3(0f, 0f, 0f);
                }
            }
        }

        [Preserve]
        [EcsUguiDownEvent(UIButtonManager.LEFT)]
        void OnLeftArrowDown(in EcsUguiDownEvent e)
        {
            _isStrafeEnd = false;
            _isButtonDown = true;
            _isLeftPointerDown = true;
        }
        [Preserve]
        [EcsUguiUpEvent(UIButtonManager.LEFT)]
        void OnLeftArrowUp(in EcsUguiUpEvent e)
        {
            _isButtonDown = false;
            _isLeftPointerDown = false;
        }

        [Preserve]
        [EcsUguiDownEvent(UIButtonManager.RIGHT)]
        void OnRightArrowDown(in EcsUguiDownEvent e)
        {
            _isStrafeEnd = false;
            _isButtonDown = true;
            _isRightPointerDown = true;
        }
        [Preserve]
        [EcsUguiUpEvent(UIButtonManager.RIGHT)]
        void OnRightArrowUp(in EcsUguiUpEvent e)
        {
            _isButtonDown = false;
            _isRightPointerDown = false;
        }
    }
}
