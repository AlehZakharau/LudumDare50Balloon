using Code.UI.Windows;
using UnityEngine;
using VContainer.Unity;

namespace Code.GamePlay
{
    public class Platform : ITickable
    {
        private readonly PlatformView platformView;
        private readonly DistanceView distanceView;
        private readonly IStage stage;
        private readonly IAbilityStore abilityStore;

        private int distance;
        private float distanceTimer;
        private float distanceTimerMax = 1f;

        public Platform(PlatformView platformView, IStage stage, DistanceView distanceView, IAbilityStore abilityStore)
        {
            this.platformView = platformView;
            this.stage = stage;
            this.distanceView = distanceView;
            this.abilityStore = abilityStore;
        }

        public void Tick()
        {
            if(stage.CurrentStage == EStage.Pause || stage.PlayerStage == EStage.Landing) return;
            platformView.transform.position += -Vector3.forward * platformView.speed * Time.deltaTime;

            distanceTimer += Time.deltaTime;
            if (distanceTimer > distanceTimerMax)
            {
                distanceTimer = 0;
                distance++;
                distanceView.ChangeText(distance.ToString());
                if (distance % 10 == 0)
                {
                    abilityStore.Coins += 10;
                }
            }
        }
    }
}