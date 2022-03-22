using System;
using System.Collections.Generic;
using UnityEngine;

namespace CommonBaseUI.Data
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField] private SaveLoadJsonWindows saveLoadJsonWindows;
        [SerializeField] private SaveLoadJsonWeb saveLoadJsonWeb;
        //[SerializeField] private SaveLoadAsyncTest saveLoadAsyncTest;

        public static DataManager Instance;

        public event Action GetDataOnSave;
        public event Action SendDataOnLoad;
        
        private SaveLoadJson saveLoadJson;
        private ManufactureDataManager manufactureDataManager;

        public GameSettingsDataManager GameSettingsDataManager { get; private set; }
        public BuildingsData buildingsData;

        private void Awake()
        {
            #if UNITY_WEBGL
                saveLoadJson = saveLoadJsonWeb;
            #else
                saveLoadJson = saveLoadJsonWindows;
            #endif
            
            GameSettingsDataManager = new GameSettingsDataManager(saveLoadJson);
            buildingsData = new BuildingsData();
            Instance = this;
        }

        // public void CreateManufactureDataManager(List<IManufactureModel> manufactures)
        // {
        //     manufactureDataManager = new ManufactureDataManager(saveLoadJson, manufactures);
        // }
        
        public void Save()
        {
            saveLoadJson.SaveToJson("BuildingData", buildingsData);
            
            GetDataOnSave?.Invoke();
            manufactureDataManager.SaveData();
        }

        public void Load()
        {
            saveLoadJson.LoadFromJson("BuildingData", buildingsData);
            
            manufactureDataManager.LoadData();
            SendDataOnLoad?.Invoke();
        }
    }
}