using System;
using Code.UI;
using Code.UI.Windows;
using UnityEngine;

namespace Code.GamePlay
{
    public interface IPlayerLife
    {
        public event Action<int> OnChangeLife; 
        public void ChangeLife(int amount);
    }
    public class PlayerLife : IPlayerLife
    {
        private readonly IAudioCenter audioCenter;
        private readonly IMediator mediator;
        private readonly IPlayerInput playerInput;
        private readonly IStage stage;
            public PlayerLife(IAudioCenter audioCenter, IMediator mediator, IPlayerInput playerInput, IStage stage)
        {
            this.audioCenter = audioCenter;
            this.mediator = mediator;
            this.playerInput = playerInput;
            this.stage = stage;
        }
        private int lifeCount;
        private int LifeCount
        {
            get => lifeCount;
            set
            {
                if(stage.PlayerStage == EStage.Landing) return;
                lifeCount = value;
                if (lifeCount < 0)
                {
                    stage.PlayerStage = EStage.Landing;
                    playerInput.Actions.Player.Disable();
                    mediator.Notify(EContext.End);
                    audioCenter.PlaySound(EAudioClips.Crash);
                }
                else
                {
                    OnChangeLife?.Invoke(lifeCount);
                }
            }
        }

        public event Action<int> OnChangeLife;

        public void ChangeLife(int amount)
        {
            Debug.Log($"Minus life {amount} {LifeCount}");
            LifeCount -= amount;
            if(amount > 0)
                audioCenter.PlaySound(EAudioClips.Landing);
        }
    }
}