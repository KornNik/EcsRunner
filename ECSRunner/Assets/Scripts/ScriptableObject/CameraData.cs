using EcsRunner.Helpers;
using UnityEngine;

namespace EcsRunner.Data
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "Data/Camera/CameraData")]
    class CameraData : ScriptableObject
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _cameraSmoothness;

        public Vector3 Offset => _offset;
        public float CameraSmoothness => _cameraSmoothness;
    }
}
