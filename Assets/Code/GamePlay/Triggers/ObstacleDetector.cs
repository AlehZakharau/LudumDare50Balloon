using System;
using UnityEngine;
using VContainer;

namespace Code.GamePlay.Triggers
{
    public class ObstacleDetector : MonoBehaviour
    {
        private IPlayerLife playerLife;
        
        [Inject]
        public void Construct(IPlayerLife playerLife)
        {
            this.playerLife = playerLife;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer($"Player"))
            {
                playerLife.ChangeLife(1);
            }
        }
    }
}