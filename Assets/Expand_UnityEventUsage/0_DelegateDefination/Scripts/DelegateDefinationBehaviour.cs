namespace Example.UEvent.Usage
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    //public delegate void StartTimeCount(float countedTime);
    [System.Serializable]
    public class TimeCountEvent : UnityEngine.Events.UnityEvent<float> { }

    public class DelegateDefinationBehaviour : MonoBehaviour
    {
        //public StartTimeCount startTimeCount;
        public TimeCountEvent startTimeCount;

        [SerializeField]
        private float countTime = 5;
        private float startTime;

        private void Awake()
        {
            // startTimeCount = new StartTimeCount(CountTriggered);
            // startTimeCount += CountTriggered; 와 같음
            startTimeCount.AddListener(CountTriggered);

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
