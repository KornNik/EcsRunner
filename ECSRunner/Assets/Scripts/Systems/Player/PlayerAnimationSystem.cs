using EcsRunner.Helpers;
using EcsRunner.Components;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace EcsRunner.Systems
{
    class PlayerAnimationSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<CharacterAnimationCompanent, MoveCompanent>> _filter = default;

        private readonly EcsPoolInject<MoveCompanent> _movePool = default;
        private readonly EcsPoolInject<CharacterAnimationCompanent> _characterAnimationPool = default;

        public void Run(IEcsSystems ecsSystems)
        {
            foreach (var entity in _filter.Value)
            {
                ref CharacterAnimationCompanent playerAnimationComponent =
                    ref _characterAnimationPool.Value.Get(entity);
                ref MoveCompanent movableComponent = ref _movePool.Value.Get(entity);

                playerAnimationComponent.Animator.SetBool(HashAnimation.IS_MOVING, movableComponent.IsMoving);
            }
        }
    }
}
