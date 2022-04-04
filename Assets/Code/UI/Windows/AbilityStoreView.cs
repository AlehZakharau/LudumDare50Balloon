using System;
using Code.GamePlay;
using CommonBaseUI.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace Code.UI.Store
{
    public class AbilityStoreView : MonoBehaviour
    {
        public Button accelerationBt;
        public Button gasMileageBt;
        public Button lifeBt;

        public int maxLevel;
        
        public Image[] accelerationIm;
        public Image[] gasMileageIm;
        public Image[] lifeIm;

        public TMP_Text accelerationPriceText;
        public TMP_Text gasMileagePriceText;
        public TMP_Text lifePriceText;

        private int accelerationLevel;
        private int gasMileageLevel;
        private int lifeLevel;

        private int AccelerationLevel => accelerationLevel > maxLevel ? 3 : accelerationLevel;
        private int GasMileageLevel => gasMileageLevel > maxLevel ? 3 : gasMileageLevel;
        private int LifeLevel => lifeLevel > maxLevel ? 3 : lifeLevel;

        private IAbilityStore abilityStore;
        private IGameConfig gameConfig;
        
        [Inject]
        public void Construct(IAbilityStore abilityStore, IGameConfig gameConfig)
        {
            this.abilityStore = abilityStore;
            this.gameConfig = gameConfig;
        }
        
        private void Start()
        {
            accelerationBt.onClick.AddListener(AddAccelerate);
            gasMileageBt.onClick.AddListener(AddGasMileage);
            lifeBt.onClick.AddListener(AddLife);

            lifePriceText.text = gameConfig.AbilityData.lifePrice[LifeLevel].ToString();
            gasMileagePriceText.text = gameConfig.AbilityData.gasMileagePrice[gasMileageLevel].ToString();
            accelerationPriceText.text = gameConfig.AbilityData.accelerationPrice[accelerationLevel].ToString();
        }

        private void AddLife()
        {
            if(lifeLevel >= maxLevel || abilityStore.Coins < gameConfig.AbilityData.lifePrice[lifeLevel]) return;
            abilityStore.UpgradeAbility(EAbility.Life);
            lifeLevel++;
            lifeIm[LifeLevel].enabled = true;
            lifePriceText.text = gameConfig.AbilityData.lifePrice[LifeLevel].ToString();
        }

        private void AddGasMileage()
        {
            if(gasMileageLevel >= maxLevel || abilityStore.Coins < gameConfig.AbilityData.gasMileagePrice[gasMileageLevel]) return;
            abilityStore.UpgradeAbility(EAbility.GasMileage);
            gasMileageLevel++;
            gasMileageIm[GasMileageLevel].enabled = true;
            gasMileagePriceText.text = gameConfig.AbilityData.gasMileagePrice[gasMileageLevel].ToString();
        }

        private void AddAccelerate()
        {
            if(accelerationLevel >= maxLevel || abilityStore.Coins < gameConfig.AbilityData.accelerationPrice[accelerationLevel]) return;
            abilityStore.UpgradeAbility(EAbility.Acceleration);
            accelerationLevel++;
            accelerationIm[AccelerationLevel].enabled = true;
            accelerationPriceText.text = gameConfig.AbilityData.accelerationPrice[accelerationLevel].ToString();
        }
    }
}