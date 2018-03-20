namespace Example.Delegate.Defination
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public delegate void StartTimeCount(float countedTime);

    public class DelegateDefinationBehaviour : MonoBehaviour
    {
        public StartTimeCount startTimeCount;

        [SerializeField]
        private float countTime = 5;
        private float startTime;

        private void Awake()
        {
            startTimeCount = new StartTimeCount(CountTriggered);

            startTime = Time.time;
        }

        public void Update()
        {
            if (startTimeCount != null)
            {
                if (startTime + countTime < Time.time)
                {
                    startTimeCount.Invoke(countTime);
                    startTime = float.MaxValue;
                }
            }
        }

        public void CountTriggered(float countTime)
        {
            Debug.LogFormat("DelegateDefinationBehaviour.CountTriggered -> {0}", countTime);
        }
    }
}
