using VContainer;
using VContainer.Unity;

namespace Code
{
    public class GameLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IPlayerInput, PlayerInput>(Lifetime.Singleton);
            
            base.Configure(builder);
        }
    }
}