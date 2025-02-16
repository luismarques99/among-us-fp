using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hintText;

        public void UpdateText(string hintMessage)
        {
            hintText.text = hintMessage;
        }
    }
}