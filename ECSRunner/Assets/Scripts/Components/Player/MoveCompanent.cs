using UnityEngine;

namespace EcsRunner.Components
{
    struct MoveCompanent
    {
        public bool IsMoving;
        public float MoveSpeed;
        public CharacterController CharacterController;
    }
}
