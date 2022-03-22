
using CommonBaseUI.Settings;

namespace CommonBaseUI.Data
{
    public class GameSettingsDataManager
    {
        public GameSettingsDataManager(SaveLoadJson saveLoadJson)
        {
            this.saveLoadJson = saveLoadJson;
        }

        private readonly GameSettingsData gameSettingsData = new GameSettingsData();
        private readonly SaveLoadJson saveLoadJson;

        private const string Filename = "GameSettings";

        #region Property

        public float SoundVolume
        {
            get => gameSettingsData.soundVolume;
            set
            {
                gameSettingsData.soundVolume = value;
                saveLoadJson.SaveToJson(Filename, gameSettingsData);
            }
        }

        public float MusicVolume
        {
            get => gameSettingsData.musicVolume;
            set
            {
                gameSettingsData.musicVolume = value;
                saveLoadJson.SaveToJson(Filename, gameSettingsData);
            }
        }

        public float VoiceVolume
        {
            get => gameSettingsData.voiceVolume;
            set
            {
                gameSettingsData.voiceVolume = value;
                saveLoadJson.SaveToJson(Filename, gameSettingsData);
            }
        }

        public bool FullScreen
        {
            get => gameSettingsData.fullScreen;
            set
            {
                gameSettingsData.fullScreen = value;
                saveLoadJson.SaveToJson(Filename, gameSettingsData);
            }
        }

        public int ResWidth
        {
            get => gameSettingsData.resWidth;
            set
            {
                gameSettingsData.resWidth = value;
                saveLoadJson.SaveToJson(Filename, gameSettingsData);
            }
        }

        public int ResHeight
        {
            get => gameSettingsData.resHeight;
            set
            {
                gameSettingsData.resHeight = value;
                saveLoadJson.SaveToJson(Filename, gameSettingsData);
            }
        }

        public ScreenResolutions16and9 Resolution
        {
            get => gameSettingsData.resolution;
            set
            {
                gameSettingsData.resolution = value;
                saveLoadJson.SaveToJson(Filename, gameSettingsData);
            }
        }

        // public Languages Languages
        // {
        //     get => gameSettingsData.currentLanguage;
        //     set
        //     {
        //         gameSettingsData.currentLanguage = value;
        //         saveLoadJson.SaveToJson(Filename, gameSettingsData);
        //     }
        // }

        #endregion

    }
}