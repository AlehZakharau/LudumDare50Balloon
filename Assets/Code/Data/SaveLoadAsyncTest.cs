using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace CommonBaseUI.Data
{
    public class SaveLoadAsyncTest : SaveLoadJson 
    {
        public override void SaveToJson(string name, ISerializable data)
        { 
            //SaveToJsonWeb(name, data);
        }
    
        private async Task SaveToJsonWeb(string name, ISerializable data)
        {
            string filePath = Path.Combine(Path.Combine
                (Application.streamingAssetsPath, name + ".json"));
            // переносим все переменные класса в формат json
            string jsonData = JsonUtility.ToJson(data);

            using (UnityWebRequest www = UnityWebRequest.Put(filePath, jsonData))
            {
                while (!www.isDone)
                {
                    await Task.Yield();
                }

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log("Upload complete!");
                }
            }
        }

        public override void LoadFromJson(string name, ISerializable data)
        {
            base.LoadFromJson(name, data);
        }
    
        private async void LoadDataFromJsonWeb(string name, ISerializable data)
        {
            //string filePath = Path.Combine(Application.dataPath, "SaveData.json");
            string filePath = Path.Combine(Path.Combine
                (Application.streamingAssetsPath, name + ".json"));
            UnityWebRequest www = new UnityWebRequest(filePath);
            www.downloadHandler = new DownloadHandlerBuffer();

            while (!www.isDone)
            {
                await Task.Yield();
            }

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                JsonUtility.FromJsonOverwrite(www.downloadHandler.text, data);
                Debug.Log($"<color=green>Game data downloaded");
            }
        }
    }
}