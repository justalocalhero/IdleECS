using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpeedrunIdle
{
    public class CurrencyGenerator : MonoBehaviour
    {
        public CurrencyManager currencyManager;
        public Currency currency;
        public TextMeshProUGUI GeneratorName;
        public ProgressBar progressBar;
        private float defaultFireTime = 2;
        private int defaultValue = 5;

        void Awake()
        {
            progressBar.onFire += HandleFire;
        }

        void Start()
        {
            progressBar.SetFireTime(defaultFireTime);
        }

        void HandleFire()
        {
            currencyManager.Add(currency, defaultValue);
        }

    }
}