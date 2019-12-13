using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedrunIdle
{
    public class TimeManager : MonoBehaviour
    {
        public float testFactor = 1;
        private float factor;

        public void OnValidate()
        {
            if(testFactor <= 0)
            {
                testFactor = 1;
            }

            factor = testFactor;
            Time.timeScale = factor;
        }
    }
}