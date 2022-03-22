using System.Runtime.Serialization;
using UnityEngine;

namespace CommonBaseUI.Data
{
    public abstract class SaveLoadJson : MonoBehaviour
    {
        public virtual void SaveToJson(string name, ISerializable data)
        {
            
        }

        public virtual void LoadFromJson(string name , ISerializable data)
        {
            
        }
    }
}
