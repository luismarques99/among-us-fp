using UnityEngine;

namespace Gameplay.Managers
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [Tooltip("Sensitivity multiplier for moving the camera around")]
        public float lookSensitivity = 1f;

        [Tooltip("Additional sensitivity multiplier for WebGL")]
        public float webglLookSensitivity = 0.25f;
        
        [Tooltip("Limit to consider an input when using a trigger on a controller")]
        public float triggerAxisThreshold = 0.4f;

        [Tooltip("Used to flip the vertical input axis")]
        public bool invertYAxis = false;
        
        [Tooltip("Used to flip the horizontal input axis")]
        public bool invertXAxis = false;
        
        
    }
}