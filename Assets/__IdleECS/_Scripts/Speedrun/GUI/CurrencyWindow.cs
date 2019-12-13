using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpeedrunIdle
{
    public class CurrencyWindow : MonoBehaviour
    {
        public TextMeshProUGUI textMesh;
        public CurrencyManager currencyManager;

        void Awake()
        {
            currencyManager.onChanged += HandleChange;
        }

        void HandleChange()
        {
            string text = "";

            foreach(Currency currency in currencyManager.currencies)
            {
                text += currency.name + " " + currency.value + "\n";
            }

            textMesh.SetText(text);
        }
    }
}