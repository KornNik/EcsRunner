using UnityEngine;

namespace EcsRunner.Data
{
    [CreateAssetMenu(fileName = "MoveData", menuName = "Data/Move/MoveData")]
    class MoveData : ScriptableObject
    {
        [SerializeField] private float _movingSpeed;

        public float MovingSpeed => _movingSpeed;
    }
}
