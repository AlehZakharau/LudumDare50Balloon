﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Code.GamePlay
{
    public interface IGasTank
    {
        public bool HasGas { get; }
        public event Action<float> OnAcceleration; 
    }
    
    public class GasTank : ITickable, IGasTank, IStartable
    {
        private readonly IPlayerInput playerInput;
        private float tankCapacity = 100;
        public bool HasGas => tankCapacity > 0;
        public event Action<float> OnAcceleration; 

        private bool accelerate;

        public GasTank(IPlayerInput playerInput)
        {
            this.playerInput = playerInput;
        }

        public void Start()
        {
            playerInput.Actions.Player.Push.started += Push;
            playerInput.Actions.Player.Push.canceled += Push;
        }

        public void Tick()
        {
            if (accelerate)
            {
                OnAcceleration?.Invoke(tankCapacity);
                tankCapacity -= Time.deltaTime;
            }
        }

        private void Push(InputAction.CallbackContext obj)
        {
            if (obj.started)
            {
                accelerate = true;
            }
            else if (obj.canceled)
            {
                accelerate = false;
            }
        }
    }
}