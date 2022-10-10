using UnityEngine;
using UnityEngine.Scripting;
using EcsRunner.Helpers;
using EcsRunner.Components;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Unity.Ugui;

namespace EcsRunner.Systems
{
    class SwipeInputSystem : EcsUguiCallbackSystem
    {
        private readonly EcsFilterInject<Inc<InputCompanent>> _filter = default;

        private readonly EcsPoolInject<InputCompanent> _inputPool = default;

        private const float MinSwipeMagnitude = 0.2f;

        Vector2 _lastTouchPos = default;

        [Preserve]
        [EcsUguiDownEvent(UIButtonManager.SWIPE)]
        void OnDownTouchListener(in EcsUguiDownEvent e)
        {
            _lastTouchPos = e.Position;
        }

        [Preserve]
        [EcsUguiUpEvent(UIButtonManager.SWIPE)]
        void OnUpTouchListener(in EcsUguiUpEvent e)
        {
            var swipe = e.Position - _lastTouchPos;
            var swipeHorizontal = swipe.x / Screen.width;

            if (Mathf.Abs(swipeHorizontal) >= MinSwipeMagnitude)
            {
                foreach (var entity in _filter.Value)
                {
                    ref InputCompanent playerInputComponent = ref _inputPool.Value.Get(entity);

                    var side = swipeHorizontal > 0f ? 1f : -1f;

                    playerInputComponent.Direction = new Vector3(side, 0f, 0f);
                }
            }
        }
    }
}
