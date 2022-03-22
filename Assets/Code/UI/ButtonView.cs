using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class ButtonView : MonoBehaviour
    {
        [SerializeField] private NavigationUIMediator navigation;
        [SerializeField] private Button button;
        [SerializeField] private EContext context;

        private void Start()
        {
            button.onClick.AddListener(PushButton);
        }

        private void PushButton()
        {
            navigation.Notify(context);
            Debug.Log($"Context: {context}");
        }
    }
}