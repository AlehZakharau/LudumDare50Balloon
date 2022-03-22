using System.Collections.Generic;
using System.Linq;

namespace CommonBaseUI.Data
{
    public class ManufactureDataManager
    {
        // public ManufactureDataManager(SaveLoadJson saveLoadJson, List<IManufactureModel> models)
        // {
        //     this.saveLoadJson = saveLoadJson;
        //     
        //     this.models = new Dictionary<IManufactureModel, int>(models.Count);
        //     data = new ManufacturesDates(models.Count);
        //     for (int i = 0; i < models.Count; i++)
        //     {
        //         this.models.Add(models[i], i);
        //         data.Manufactures[i] = new ManufactureData();
        //     }
        // }

        private readonly BuildingsData data;
        private readonly SaveLoadJson saveLoadJson;

        private const string Filename = "ManufactureData";

        //private readonly Dictionary<IManufactureModel, int> models;

        public void SaveData()
        {
            // foreach (var manufacture in models)
            // {
            //     data.Manufactures[manufacture.Value].level = manufacture.Key.ManufactureData.Level;
            //     data.Manufactures[manufacture.Value].resourceAmount = manufacture.Key.ResourceAmount;
            //     data.Manufactures[manufacture.Value].demandResources =
            //         manufacture.Key.ManufactureData.ProductionResources.Values.ToArray();
            //     data.Manufactures[manufacture.Value].upgradeResources =
            //         manufacture.Key.ManufactureData.UpgradeResources.Values.ToArray();
            // }
            saveLoadJson.SaveToJson(Filename, data);
        }

        public void LoadData()
        {
            saveLoadJson.LoadFromJson(Filename, data);
            // foreach (var manufacture in models)
            // {
            //     manufacture.Key.ManufactureData.Level = data.Manufactures[manufacture.Value].level;
            //     manufacture.Key.ResourceAmount = data.Manufactures[manufacture.Value].resourceAmount;
            //     manufacture.Key.ManufactureData.SetDemandResourceAmount(data.Manufactures[manufacture.Value].demandResources);
            //     manufacture.Key.ManufactureData.SetUpgradeResourceAmount(data.Manufactures[manufacture.Value].upgradeResources);
            // }
        }
    }
}