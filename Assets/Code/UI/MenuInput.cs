using System;
using UnityEngine;

namespace Code.UI
{
    public class MenuInput : MonoBehaviour
    {
        [SerializeField] private MediatorUI mediator;
        private Actions actions;
        private void Start()
        {
            //actions = PlayerInput.Instance.Actions;
        }
        // private void Update()
        // {
        //     var esc = actions.Menu.Menu.triggered;
        //
        //     if (esc)
        //     {
        //         Debug.Log("pause");
        //         navigation.Notify(EContext.Pause);
        //     }
        // }
        
        
    }
}