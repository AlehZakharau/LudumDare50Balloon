using System;
using System.Runtime.Serialization;
using Code.GamePlay;
using UnityEngine;
using UnityEngine.Audio;

namespace CommonBaseUI.Data
{
    public interface IGameConfig
    {
        public CommonData CommonData { get;}
        public AbilityData AbilityData { get; }

        public AudioData AudioData { get; }
    }
    [CreateAssetMenu(fileName = "GameConfig", menuName = "DataBase/GameConfig", order = 0)]
    public class GameConfig : ScriptableObject, IGameConfig
    {
        [SerializeField] private CommonData commonData;
        [SerializeField] private AbilityData abilityData;
        [SerializeField] private AudioData audioData;
        public CommonData CommonData => commonData;
        public AbilityData AbilityData => abilityData;
        public AudioData AudioData => audioData;
    }

    [Serializable]
    public class CommonData : ISerializable
    {
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }
    }
    
    [Serializable]
    public class AbilityData : ISerializable
    {
        public float[] acceleration;
        public float[] gasMileage;
        public int[] life;

        public int[] accelerationPrice;
        public int[] gasMileagePrice;
        public int[] lifePrice;
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
        }
    }

    [Serializable]
    public class AudioData
    {
        public AudioMixerGroup[] groups;
    }
}