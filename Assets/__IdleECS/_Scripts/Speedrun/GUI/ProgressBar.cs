using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpeedrunIdle
{
    public class ProgressBar : MonoBehaviour
    {
        public const float minViewingFireTime = .5f;        

        private Slider slider;
        private float secondsToFire;
        private float nextFireTime;

        public delegate void OnFire();
        public OnFire onFire;

        void Awake()
        {
            slider = GetComponentInChildren<Slider>();
        }

        void Start()
        {
            ResetFireTime();
        }

        void Update()
        {
            float progress = GetProgress();
            slider.value = (secondsToFire > minViewingFireTime) ? progress : 1;

            if(progress >= 1) 
            {
                ResetFireTime();
                if(onFire != null) onFire();
            }
        }

        public void SetFireTime(float secondsToFire)
        {
            float currentFirePercent = GetProgress();
            this.secondsToFire = secondsToFire;
            nextFireTime = Time.time + secondsToFire * (1 - currentFirePercent);
        } 

        public void ResetFireTime()
        {
            nextFireTime = Time.time + secondsToFire;
        }

        public float GetProgress()
        {
            float time = Time.time;
            float clampedTime = Mathf.Clamp(time, time, nextFireTime);
            float remainingTime = nextFireTime - clampedTime;
            float clampedRemainingTime = Mathf.Clamp(remainingTime, 0, secondsToFire);
            float normalizedRemainingTime = clampedRemainingTime / secondsToFire;
            float progress = 1 - normalizedRemainingTime;

            return progress;

        }
    }
}