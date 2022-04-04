﻿using System;
using System.Collections.Generic;
using CommonBaseUI.Data;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace Code
{
    public interface IAudioCenter
    {
        public void PlaySound(EAudioClips clipName);
        public void PlaySound(EAudioClips clipName, SourceConfig config);
    }
    public class AudioCenter : IAudioCenter
    {
        private readonly AudioDB audioDB;
        private readonly AudioSourceFabric fabric;
        private readonly Stack<AudioSource> soundPlayers;

        public AudioCenter(AudioSourceFabric fabric, AudioDB audioDB, IGameConfig gameConfig)
        {
            this.fabric = fabric;
            this.audioDB = audioDB;
            soundPlayers = new Stack<AudioSource>();
        }

        public void PlaySound(EAudioClips clipName)
        {
            var source = FindAudioPlayer();
            source.clip = audioDB.GetClip(clipName);
            source.Play();
        }

        public void PlaySound(EAudioClips clipName, EAudioMixerGroupNames groupName)
        {
            var source = FindAudioPlayer();
            source.clip = audioDB.GetClip(clipName);
            source.outputAudioMixerGroup = audioDB.GetMixerGroup(groupName);
            source.Play();

        }

        public void PlaySound(EAudioClips clipName, SourceConfig config)
        {
            var source = FindAudioPlayer();
            SetConfig(source, config);
            source.clip = audioDB.GetClip(clipName);
            source.Play();
        }

        private void SetConfig(AudioSource source, SourceConfig config)
        {
            source.loop = config.Loop;
            source.pitch += Random.Range(-config.PitchRange, config.PitchRange);
            source.outputAudioMixerGroup = audioDB.GetMixerGroup(config.MixerGroup);
        }

        private AudioSource FindAudioPlayer()
        {
            if (soundPlayers.Count == 0)
            {
               return CreateNewSource();
            }

            foreach (var audioPlayer in soundPlayers)
            {
                if (!audioPlayer.isPlaying)
                    return audioPlayer;
            }

            return CreateNewSource();
        }

        private AudioSource CreateNewSource()
        {
            var newSource = fabric.CreateSource();
            soundPlayers.Push(newSource);
            return newSource;
        }

        
    }

    public enum EAudioMixerGroupNames
    {
        Master,
        Music,
        Sound,
        Environment,
        Balloon,
        Wind,
    }
}