namespace Example.Delegate.Defination
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(TextMesh))]
    public class TriggeredText : MonoBehaviour
    {
        [SerializeField]
        private DelegateDefinationBehaviour behaviour;

        private void OnEnable()
        {
            if (behaviour != null)
                behaviour.startTimeCount = TimeTriggered;
        }

        private void OnDisable()
        {
            if (behaviour != null)
                behaviour.startTimeCount = null;
        }

        public void TimeTriggered(float endTime)
        {
            Debug.LogFormat("TriggerText.TimeTriggered >> {0}", endTime);

            TextMesh textMesh = GetComponent<TextMesh>();
            textMesh.text = string.Format("TRIGGER TIME : {0}", endTime);
        }
    }
}