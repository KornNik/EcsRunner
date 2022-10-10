using UnityEngine;
using EcsRunner.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsRunner.Systems
{
    class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<MoveCompanent, InputCompanent>> _filter = default;

        private readonly EcsPoolInject<MoveCompanent> _movePool = default;
        private readonly EcsPoolInject<InputCompanent> _playerInputPool = default;

        public void Run(IEcsSystems ecsSystems)
        {
            foreach (int entity in _filter.Value)
            {
                ref MoveCompanent movable = ref _movePool.Value.Get(entity);
                ref InputCompanent input = ref _playerInputPool.Value.Get(entity);

                Vector3 disiredMove = (movable.CharacterController.transform.forward * movable.MoveSpeed +
                    movable.CharacterController.transform.right * input.Direction.x * movable.MoveSpeed);
                movable.CharacterController.Move(disiredMove);
                if (movable.CharacterController.velocity.sqrMagnitude > 0)
                {
                    movable.IsMoving = true;
                }
                else { movable.IsMoving = false; }
            }

        }
    }
}
