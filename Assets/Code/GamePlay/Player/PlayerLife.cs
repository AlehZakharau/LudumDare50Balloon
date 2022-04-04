using System;

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
        public PlayerLife(IAudioCenter audioCenter)
        {
            this.audioCenter = audioCenter;
        }
        private int lifeCount;
        private int LifeCount
        {
            get => lifeCount;
            set
            {
                lifeCount = value;
                if (lifeCount < 0)
                {
                    // end
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
            LifeCount -= amount;
            if(amount > 0)
                audioCenter.PlaySound(EAudioClips.Landing);
        }
    }
}