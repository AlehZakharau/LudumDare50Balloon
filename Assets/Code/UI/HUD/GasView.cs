using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.GamePlay
{
    public class GasView : MonoBehaviour
    {
        [SerializeField] private Slider gasSlider;
        
        private IGasTank gasTank;
        
        [Inject]
        public void Construct(IGasTank gasTank)
        {
            this.gasTank = gasTank;
            gasTank.OnAcceleration += GasTankOnOnAcceleration;
        }

        private void GasTankOnOnAcceleration(float obj)
        {
            gasSlider.value = obj;
        }
    }
}