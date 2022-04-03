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

        private int accelerationLevel;
        private int gasMileageLevel;
        private int lifeLevel;

        public int Coins { get; set; }

        public AbilityStore(IGameConfig gameConfig,IPlayerLife playerLife)
        {
            this.gameConfig = gameConfig;
            this.playerLife = playerLife;
        }


        public void UpgradeAbility(EAbility ability)
        {
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