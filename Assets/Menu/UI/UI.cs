using System;
using TMPro;
using UnityEngine;

namespace Menu.UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextMeshPro pointText;
        [SerializeField] private TextMeshPro healthText;

        private void Start()
        {
            //Bind event
            GameManager.instance.EventPointChange += HandlePointChange;
            GameManager.instance.EventHealthChange += HandleHealthChange;
            
            pointText.text = GameManager.instance.Point.ToString();
            healthText.text = "Health : " + GameManager.instance.Health;
        }

        private void HandlePointChange(int value)
        {
            pointText.text = value.ToString();
        }

        private void HandleHealthChange(int value)
        {
            healthText.text = "Health : " + value;
        }
    }
}
