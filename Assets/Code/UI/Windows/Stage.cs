using System;
using Code.GamePlay;

namespace Code.UI.Windows
{
    public interface IStage
    {
        public void ChangeStage(EStage eStage);
        public EStage CurrentStage { get; }
    }
    public class Stage : IStage
    {
        private readonly IPlayerInput playerInput;
        
        public Stage(IPlayerInput playerInput)
        {
            this.playerInput = playerInput;
        }
        public void ChangeStage(EStage eStage)
        {
            CurrentStage = eStage;
            
            switch (eStage)
            {
                case EStage.Game:
                    playerInput.Actions.Player.Enable();
                    break;
                case EStage.Pause:
                    playerInput.Actions.Player.Disable();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(eStage), eStage, null);
            }
        }

        public EStage CurrentStage { get; private set; }
    }

    public enum EStage
    {
        Pause,
        Game,
    }
}