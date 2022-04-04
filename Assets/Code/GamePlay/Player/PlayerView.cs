using UnityEngine;

namespace Code.GamePlay
{
    public class PlayerView : MonoBehaviour
    {
        [Header("Ground Check")]
        public Transform[] groundChecker;
        public float groundCheckerRadius = 0.1f;
        public LayerMask groundLayer;
        
        [Header("Gravity scaler")]
        public float planningScaler = 0.1f;
        public float fallingGravityScaler = 0.3f;
        
        [Header("Components")]
        public Transform Transform;
        public Rigidbody Rig;

        [Header("VFX")]
        public ParticleSystem[] fire;
        public ParticleSystem crash;

    }
}