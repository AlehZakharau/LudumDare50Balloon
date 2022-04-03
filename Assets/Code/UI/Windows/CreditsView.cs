using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Windows
{
    public class CreditsView : MonoBehaviour
    {
        [SerializeField] private Button twitter;
        [SerializeField] private Button itch;


        private void Start()
        {
            twitter.onClick.AddListener(OpenTwitter);
            itch.onClick.AddListener(OpenItch);
        }

        private void OpenItch()
        {
            Application.OpenURL("https://alehzaharau.itch.io/");
        }

        private void OpenTwitter()
        {
            Application.OpenURL("https://twitter.com/ZaharauAleh");
        }
    }
}