﻿using Code.UI.Windows;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Code.GamePlay
{
    public class PlayerMovement : ITickable, IFixedTickable, IStartable
    {
        private readonly IPlayerInput playerInput;
        private readonly IGasTank gasTank;
        private readonly IAbilityStore abilityStore;
        private readonly IStage stage;
        private readonly PlayerView playerView;
        private readonly Rigidbody rig;

        private bool accelerate;
        private bool planning;

        public PlayerMovement(IPlayerInput playerInput, PlayerView playerView, IGasTank gasTank, 
            IAbilityStore abilityStore, IStage stage)
        {
            this.playerInput = playerInput;
            this.playerView = playerView;
            this.stage = stage;
            this.gasTank = gasTank;
            this.abilityStore = abilityStore;
            rig = playerView.Rig;
        }

        public void Start()
        {
            playerInput.Actions.Player.Down.started += Down;
            playerInput.Actions.Player.Down.canceled += Down;
            
            playerInput.Actions.Player.Push.started += Push;
            playerInput.Actions.Player.Push.canceled += Push;
        }

        public void Tick()
        {
            if (IsGrounded(playerView.groundChecker[0]))
            {
                //stop moving
                playerInput.Actions.Player.Disable();
            }
        }

        public void FixedTick()
        {
            if (stage.CurrentStage == EStage.Pause)
            {
                rig.velocity = Vector3.zero;
                return;
            }
            if (accelerate)
            {
                rig.AddForce(Physics.gravity * (abilityStore.Acceleration) * rig.mass);
            }
            else if(planning)
            {
                rig.AddForce(Physics.gravity * playerView.planningScaler * rig.mass);
            }
            else
            {
                rig.AddForce(Physics.gravity * (playerView.fallingGravityScaler) * rig.mass);
            }
        }

        private void Down(InputAction.CallbackContext obj)
        {
            if (obj.started)
            {
                planning = true;
            }
            else if(obj.canceled)
            {
                planning = false;
            }
        }

        private void Push(InputAction.CallbackContext obj)
        {
            if(!gasTank.HasGas) return;
            if (obj.started)
            {
                accelerate = true;
            }
            else if (obj.canceled)
            {
                accelerate = false;
            }
        }
        
        private bool IsGrounded(Transform checker)
        {
            return Physics.CheckSphere(checker.position, playerView.groundCheckerRadius, playerView.groundLayer);
        }
    }
}