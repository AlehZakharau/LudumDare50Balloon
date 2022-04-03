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
        }
    }
}