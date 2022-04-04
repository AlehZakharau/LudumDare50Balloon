using System;
using CommonBaseUI.Data;

namespace Code.GamePlay
{
    public interface IAbilityStore
    {
        public void UpgradeAbility(EAbility ability);
        public float Acceleration { get; }
        public float GasMileage { get; }
        public int Life { get; }
        public int Coins { get; set; }
    }
    
    public class AbilityStore : IAbilityStore
    {
        private readonly IGameConfig gameConfig;
        private readonly IPlayerLife playerLife;
        private readonly IAudioCenter audioCenter;
        private readonly CoinView coinView;

        private int accelerationLevel;
        private int gasMileageLevel;
        private int lifeLevel;

        private int coins;
        public int Coins
        {
            get => coins;
            set
            {
                coins = value;
                coinView.coinText.text = coins.ToString();
                coinView.coinText_1.text = coins.ToString();
            }
        }

        public AbilityStore(IGameConfig gameConfig,IPlayerLife playerLife, IAudioCenter audioCenter, CoinView coinView)
        {
            this.gameConfig = gameConfig;
            this.playerLife = playerLife;
            this.audioCenter = audioCenter;
            this.coinView = coinView;
        }


        public void UpgradeAbility(EAbility ability)
        {
            audioCenter.PlaySound(EAudioClips.Upgrade);
            switch (ability)
            {
                case EAbility.Acceleration:
                    Coins -= gameConfig.AbilityData.accelerationPrice[accelerationLevel];
                     accelerationLevel++;
                    break;
                case EAbility.GasMileage:
                    Coins -= gameConfig.AbilityData.gasMileagePrice[gasMileageLevel];
                    gasMileageLevel++;
                    break;
                case EAbility.Life:
                    Coins -= gameConfig.AbilityData.lifePrice[lifeLevel];
                    lifeLevel++;
                    playerLife.ChangeLife(-Life);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ability), ability, null);
            }
        }

        public float Acceleration => gameConfig.AbilityData.acceleration[accelerationLevel];
        public float GasMileage => gameConfig.AbilityData.gasMileage[gasMileageLevel];
        public int Life => gameConfig.AbilityData.life[lifeLevel];
    }


    public enum EAbility
    {
        Acceleration,
        GasMileage,
        Life
    }
}