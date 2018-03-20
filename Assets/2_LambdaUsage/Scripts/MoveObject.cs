namespace Example.Delegate.LambdaUsage
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public delegate void CollideObjObj(Vector3 point, Vector3 normal, Collider other1, Collider other2, float distance);

    public class MoveObject : MonoBehaviour
    {
        public float speed;
        [NonSerialized]
        public Vector3 direction;
        public Transform target;

        private CollideObjObj collide { get; set; }
        private RaycastHit[] hits;
        private bool isHit;
        private bool isStart;

        private void Awake()
        {
            isHit = false;
            hits = new RaycastHit[10];
            direction = (target.position - transform.position).normalized;
        }

        private void Update()
        {
            if (!isHit && isStart)
                transform.position = transform.position + direction * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            int number = Physics.RaycastNonAlloc(transform.position - direction * speed * 60 * Time.deltaTime, direction, hits);

            if (number > 0)
            {
                isHit = true;
                RaycastHit hit = hits[0];


                if (collide != null)
                    collide.Invoke(hit.point, hit.normal, GetComponent<Collider>(), other, (transform.position - other.transform.position).magnitude);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.contacts.Length > 0)
                if (collide != null)
                {
                    ContactPoint contact = collision.contacts[0];
                    collide.Invoke(contact.point, contact.normal, contact.thisCollider, contact.otherCollider, contact.separation);
                }
                    
        }

        public bool StartMoveToTarget(CollideObjObj whenCollide)
        {
            if (!isStart)
            {
                isStart = true;

                if (collide != null)
                    collide += whenCollide;

                return true;
            }

            return false;
        }
    }
}