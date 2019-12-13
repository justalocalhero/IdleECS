using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedrunIdle
{
    [CreateAssetMenu(menuName="Currency/CurrencyManager")]
    public class CurrencyManager : ScriptableObject
    {
        public Currency[] currencies;

        public delegate void OnChanged();
        public OnChanged onChanged;

        void OnValidate()
        {
            ValidateCurrency();
        }

        private void ValidateCurrency()
        {
            for(int i = 0; i < currencies.Length; i++)
            {
                currencies[i].index = i;
            }
        }

        public void Add(Currency currency, int value)
        {
            currency.value += value;
            
            if(onChanged != null) onChanged();
        }


    }
}