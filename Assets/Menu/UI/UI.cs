using System;
using TMPro;
using UnityEngine;

namespace Menu.UI
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private TextMeshPro pointText;

        private void Awake()
        {
            GameManager.instance.EventPointChange += HandlePointChange;
        }

        private void Start()
        {
            pointText.text = GameManager.instance.Point.ToString();
        }

        private void HandlePointChange(int value)
        {
            pointText.text = value.ToString();
        }
    }
}
