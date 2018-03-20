namespace Example.Delegate.Event.Usage
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public delegate void SpacePressed();
    public delegate void SpaceReleased();

    public class DelegateUsageBehaviour : MonoBehaviour
    {
        public event SpacePressed pressed;
        public event SpaceReleased released;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                pressed.Invoke();
            else if (Input.GetKeyUp(KeyCode.Space))
                released();
        }
    }
}
