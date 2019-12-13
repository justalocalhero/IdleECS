using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedrunIdle
{
    [CreateAssetMenu(menuName="Currency/Currency")]
    public class Currency : ScriptableObject
    {
        public string currencyName;
        public int index;
        public int value;
    }
}