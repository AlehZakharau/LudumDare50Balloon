using UnityEngine;

namespace Code.UI
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private Canvas windowCanvas;

        public void OpenWindow()
        {
            windowCanvas.enabled = true;
        }

        public void CloseWindow()
        {
            windowCanvas.enabled = false;
        }
    }
}