using System;
using TMPro;
using UnityEngine;

namespace Menu.UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextMeshPro pointText;

        private void Start()
        {
            GameManager.instance.EventPointChange += HandlePointChange;
            pointText.text = GameManager.instance.Point.ToString();
        }

        private void HandlePointChange(int value)
        {
            Debug.Log("handle Change");
            pointText.text = value.ToString();
        }
    }
}
