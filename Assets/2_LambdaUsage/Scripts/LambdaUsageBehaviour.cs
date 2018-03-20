namespace Example.Delegate.LambdaUsage
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class LambdaUsageBehaviour : MonoBehaviour
    {
        [SerializeField]
        private MoveObject objectColide;
        [SerializeField]
        private GameObject particle;
        [SerializeField]
        private float explosionForce;
        [SerializeField]
        private UnityEngine.UI.Text text;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                bool validated = objectColide.StartMoveToTarget(
                                (point, normal, other1, other2, distance) =>
                                {
                                    Rigidbody rigidbody = other1.GetComponent<Rigidbody>();
                                    rigidbody.isKinematic = false;
                                    rigidbody.useGravity = true;
                                    rigidbody.AddForce(normal * explosionForce);

                                    Rigidbody otherRigidbody = other2.GetComponent<Rigidbody>();
                                    otherRigidbody.isKinematic = false;
                                    otherRigidbody.useGravity = true;
                                    otherRigidbody.AddForce(normal * explosionForce * -1);

                                    particle.transform.position = point;
                                    particle.SetActive(true);

                                    text.text = "BOMB!!";
                                }
                                );

                if (validated)
                {
                    text.text = "START";
                }
            }
        }
    }
}