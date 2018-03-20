namespace Example.Delegate.Usage
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(TextMesh))]
    public class MagnitudeText : MonoBehaviour
    {
        [SerializeField]
        private GenericDelegateBehaviour magnitudeBehaviour;
        private TextMesh textMesh;

        private void Awake()
        {
            textMesh = GetComponent<TextMesh>();
        }

        private void Update()
        {
            textMesh.text = magnitudeBehaviour.currentMagnitude().ToString();
        }
    }
}