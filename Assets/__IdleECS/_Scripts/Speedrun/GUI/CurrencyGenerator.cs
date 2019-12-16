using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SpeedrunIdle
{
    public class CurrencyGenerator : MonoBehaviour
    {
        public string generatorName;
        public int level;
        public CurrencyManager currencyManager;
        public Currency currency;
        public TextMeshProUGUI generatorNameMesh;
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
            generatorNameMesh.SetText(generatorName);
        }

        void HandleFire()
        {
            currencyManager.Add(currency, defaultValue);
        }

    }
}