namespace Example.UEvent.Usage
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    //public delegate void SpacePressed();
    //public delegate void SpaceReleased();

    [System.Serializable]
    public class SpacePressedEvent : UnityEngine.Events.UnityEvent { }
    [System.Serializable]
    public class SpaceReleasedEvent : UnityEngine.Events.UnityEvent { }

    public class DelegateUsageBehaviour : MonoBehaviour
    {
        //public SpacePressed pressed { get; set; }
        //public SpaceReleased released { get; set; }

        public SpacePressedEvent pressed;
        public SpaceReleasedEvent released;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                pressed.Invoke();
            else if (Input.GetKeyUp(KeyCode.Space))
                //released();
                released.Invoke();
        }
    }
}
