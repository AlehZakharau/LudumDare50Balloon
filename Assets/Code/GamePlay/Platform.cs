using UnityEngine;
using VContainer.Unity;

namespace Code.GamePlay
{
    public class Platform : ITickable
    {
        private readonly PlatformView platformView;

        public Platform(PlatformView platformView)
        {
            this.platformView = platformView;
        }

        public void Tick()
        {
            platformView.transform.position += Vector3.left * platformView.speed * Time.deltaTime;
        }
    }
}