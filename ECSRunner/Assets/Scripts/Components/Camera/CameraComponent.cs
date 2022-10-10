using UnityEngine;

namespace EcsRunner.Components
{
    struct CameraComponent
    {
        public Vector3 Offset;
        public Vector3 CurrentVelocity;
        public Transform CameraTransform;

        public float CameraSmoothness;
    }
}
