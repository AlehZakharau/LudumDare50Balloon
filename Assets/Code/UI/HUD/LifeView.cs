using System;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.GamePlay
{
    public class LifeView : MonoBehaviour
    {
        public Image[] lifeIm;

        private IPlayerLife playerLife;
        
        [Inject]
        public void Construct(IPlayerLife playerLife)
        {
            this.playerLife = playerLife;
            
            playerLife.OnChangeLife += PlayerLifeOnOnChangeLife;
        }

        private void PlayerLifeOnOnChangeLife(int obj)
        {
            for (int i = 0; i < lifeIm.Length; i++)
            {
                lifeIm[i].enabled = i < obj;
            }
        }

        private void OnDestroy()
        {
            playerLife.OnChangeLife -= PlayerLifeOnOnChangeLife;
        }
    }
}