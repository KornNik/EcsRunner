using UnityEngine;
using EcsRunner.Helpers;
using EcsRunner.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsRunner.Systems
{
    class PlayerInputKeyboardSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<InputCompanent>> _filter = default;

        private readonly EcsPoolInject<InputCompanent> _inputPool = default;

        public void Run(IEcsSystems ecsSystems)
        {
            foreach (var entity in _filter.Value)
            {
                ref InputCompanent playerInputComponent = ref _inputPool.Value.Get(entity);

                playerInputComponent.Direction = new Vector3
                    (Input.GetAxis(AxisManager.HORIZONTAL), 0f, 0f);

            }
        }
    }
}
