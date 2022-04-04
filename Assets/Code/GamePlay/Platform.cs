using Code.UI.Windows;
using UnityEngine;
using VContainer.Unity;

namespace Code.GamePlay
{
    public class Platform : ITickable
    {
        private readonly PlatformView platformView;
        private readonly IStage stage;

        public Platform(PlatformView platformView, IStage stage)
        {
            this.platformView = platformView;
            this.stage = stage;
        }

        public void Tick()
        {
            if(stage.CurrentStage == EStage.Pause) return;
            platformView.transform.position += -Vector3.forward * platformView.speed * Time.deltaTime;
        }
    }
}