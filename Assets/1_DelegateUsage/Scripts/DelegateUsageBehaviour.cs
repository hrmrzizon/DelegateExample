namespace Example.Delegate.Usage
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public delegate void SpacePressed();
    public delegate void SpaceReleased();

    public class DelegateUsageBehaviour : MonoBehaviour
    {
        public SpacePressed pressed { get; set; }
        public SpaceReleased released { get; set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                pressed.Invoke();
            else if (Input.GetKeyUp(KeyCode.Space))
                released();
        }
    }
}
