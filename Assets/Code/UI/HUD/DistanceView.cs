using TMPro;
using UnityEngine;

namespace Code.GamePlay
{
    public class DistanceView : MonoBehaviour
    {
        public TMP_Text Text;
        public TMP_Text Text_1;


        public void ChangeText(string text)
        {
            Text.text = text;
            Text_1.text = text;
        }
    }
}