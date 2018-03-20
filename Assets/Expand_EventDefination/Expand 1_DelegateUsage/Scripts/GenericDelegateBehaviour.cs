namespace Example.Delegate.Event.Usage
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public delegate Return GetValue<Return>();

    public class GenericDelegateBehaviour : MonoBehaviour
    {
        //*
        public float currentMagnitude { get { return transform.position.magnitude; } }
        /*/
        public event GetValue<float> currentMagnitude;
        
        private void Awake()
        {
            currentMagnitude = () => { return transform.position.magnitude; };
        }
        //*/
    }
}