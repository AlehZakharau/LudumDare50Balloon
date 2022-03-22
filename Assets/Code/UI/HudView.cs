using System;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class HudView : MonoBehaviour
    {
        //[SerializeField] private MilkCollector milkCollector;
        //[SerializeField] private MouseCollector mouseCollector;
        [Header("Text")]
        [SerializeField] private TMP_Text milkText;
        [SerializeField] private TMP_Text miceText;
        [Header("Parameters")]
        [SerializeField] private int maxMilkValue;


        private int milkCount;
        private int mouseCount;
        private void Start()
        {
            //milkCollector.onAddingMilk += OnAddingMilk;
            //mouseCollector.onEatingMouse += OnEatingMouse;
            milkText.text = $"{milkCount} / {maxMilkValue}";
            miceText.text = "0";

        }

        private void OnEatingMouse()
        {
            mouseCount++;
            miceText.text = $"{mouseCount}";
        }

        private void OnAddingMilk()
        {
            milkCount++;
            if(milkCount > maxMilkValue) return;
            milkText.text = $"{milkCount} / {maxMilkValue}";
        }
    }
}