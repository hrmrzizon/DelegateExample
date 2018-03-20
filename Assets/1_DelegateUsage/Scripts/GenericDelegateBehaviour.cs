namespace Example.Delegate.Usage
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public delegate Return GetValue<Return>();

    public class GenericDelegateBehaviour : MonoBehaviour
    {
        public GetValue<float> currentMagnitude;

        private void Awake()
        {
            currentMagnitude = () => { return transform.position.magnitude; };
        }
    }
}