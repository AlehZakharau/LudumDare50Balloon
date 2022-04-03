using System;
using System.Collections.Generic;
using Code.UI.Windows;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using VContainer;

namespace Code.UI
{
    public interface IMediator
    {
        public void Notify(EContext ev);
    }
    public class MediatorUI : MonoBehaviour, IMediator
    {
        [SerializeField] private Window[] windowsView;
        
        private Dictionary<EWindows,Window> windows;
        private IPlayerInput playerInput;
        private IAudioCenter audioCenter;
        private IStage stage;

        private Window previousWindow;
        private Window currentWindow;


        [Inject]
        public void Construct(IPlayerInput playerInput, IAudioCenter audioCenter, IStage stage)
        {
            windows = new Dictionary<EWindows, Window>();
            this.playerInput = playerInput;
            this.audioCenter = audioCenter;
            this.stage = stage;
            
            
            foreach (var window in windowsView)
            {
                windows.Add(window.WindowType, window);
            }
            currentWindow = this.windows[EWindows.Tutorial];
        }

        public void Notify(EContext ev)
        {
            //audioCenter.PlaySound(EAudioClips.Button);
            switch (ev)
            {
                case EContext.NewGame:
                    SceneManager.LoadScene(sceneBuildIndex: 0);
                    break;
                case EContext.Continue:
                    currentWindow.CloseWindow();
                    OpenWindow(windows[EWindows.MainMenu]);
                    stage.ChangeStage(EStage.Game);
                    break;
                case EContext.Pause:
                    if (stage.CurrentStage == EStage.Game)
                    {
                        OpenWindow(windows[EWindows.Pause]);
                        stage.ChangeStage(EStage.Pause);
                    }
                    else
                    {
                        OpenWindow(windows[EWindows.MainMenu]);
                        stage.ChangeStage(EStage.Game);
                    }
                    break;
                case EContext.Setting:
                    OpenWindow(windows[EWindows.Settings]);
                    stage.ChangeStage(EStage.Pause);
                    break;
                case EContext.Credits:
                    OpenWindow(windows[EWindows.Credits]);
                    stage.ChangeStage(EStage.Pause);
                    break;
                case EContext.Back:
                    OpenWindow(previousWindow);
                    break;
                case EContext.Tutorial:
                    OpenWindow(windows[EWindows.Tutorial]);
                    stage.ChangeStage(EStage.Pause);
                    break;
                case EContext.Store:
                    OpenWindow(windows[EWindows.Store]);
                    stage.ChangeStage(EStage.Pause);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(ev), ev, null);
            }
        }

        private void Start()
        {
            playerInput.Actions.Menu.Pause.started += context => Notify(EContext.Pause);
            playerInput.Actions.Menu.Store.started += context => Notify(EContext.Store);
            playerInput.Actions.Menu.Credits.started += context => Notify(EContext.Credits);
            playerInput.Actions.Menu.AudioSettings.started += context => Notify(EContext.Setting);
            playerInput.Actions.Menu.Back.started += context => Notify(EContext.Continue);
            playerInput.Actions.Menu.CloseTutorial.started += CloseTutorial;
        }

        private void CloseTutorial(InputAction.CallbackContext obj)
        {
            if (obj.started && currentWindow == windows[EWindows.Tutorial])
            {
                Notify(EContext.Continue);
            }
        }


        private void OpenWindow(Window window)
        {
            currentWindow.CloseWindow();
            previousWindow = currentWindow;
            window.OpenWindow();
            currentWindow = window;
        }
    }

    public enum EContext
    {
        NewGame,
        Continue,
        Pause,
        Setting,
        Store,
        Back,
        Credits,
        Tutorial
    }

    public enum EWindows
    {
        MainMenu,
        Settings,
        Store,
        Credits,
        Pause,
        Tutorial
    }
}