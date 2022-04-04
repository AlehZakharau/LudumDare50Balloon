using System;
using CommonBaseUI.Data;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Code.Audio
{
    public class BalloonAudio : IStartable
    {
        private readonly IAudioCenter audioCenter;
        private readonly IPlayerInput playerInput;
        private readonly IGameConfig gameConfig;
        private readonly IAudioSourceFabric fabric;
        private readonly AudioDB audioDB;

        private AudioSource balloonSource;

        private float normalVolume = 0.8f;

        public BalloonAudio(IAudioCenter audioCenter, IPlayerInput playerInput, IGameConfig gameConfig,
            IAudioSourceFabric fabric, AudioDB audioDB)
        {
            this.audioCenter = audioCenter;
            this.playerInput = playerInput;
            this.gameConfig = gameConfig;
            this.fabric = fabric;
            this.audioDB = audioDB; 

            balloonSource = fabric.CreateSource();
        }
        public void Start()
        {
            audioCenter.PlaySound(EAudioClips.Environment, new SourceConfig(true));
            audioCenter.PlaySound(EAudioClips.Wind, new SourceConfig(true));
            
            playerInput.Actions.Player.Push.started += Push;
            playerInput.Actions.Player.Push.canceled += Push;
            playerInput.Actions.Player.Down.started += Down;
            playerInput.Actions.Player.Down.canceled += Down;
            
            balloonSource.loop = true;
            balloonSource.clip = audioDB.GetClip(EAudioClips.NormalBurst);
            balloonSource.Play();
            balloonSource.volume = normalVolume;
        }

        private void Down(InputAction.CallbackContext obj)
        {
            if (obj.started)
            {
                balloonSource.clip = audioDB.GetClip(EAudioClips.LowBurst);
                balloonSource.Play();
                
            }
            else if (obj.canceled)
            {
                balloonSource.clip = audioDB.GetClip(EAudioClips.NormalBurst);
                balloonSource.Play();
            }
        }
        
        private void Push(InputAction.CallbackContext obj)
        {
            if (obj.started)
            {
                balloonSource.volume = 1f;
            }
            else if (obj.canceled)
            {
                balloonSource.volume = normalVolume;
            }
        }
    }
}