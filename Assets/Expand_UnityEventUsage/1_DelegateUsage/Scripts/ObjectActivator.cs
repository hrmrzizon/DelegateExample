namespace Example.UEvent.Usage
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ObjectActivator : MonoBehaviour
    {
        [SerializeField]
        private DelegateUsageBehaviour behaviour;

        [SerializeField]
        private GameObject cube;
        [SerializeField]
        private GameObject sphere;

        //private void OnEnable()
        //{
        //    behaviour.pressed += Cube;
        //    behaviour.released += Sphere;
        //}

        //private void OnDisable()
        //{
        //    behaviour.pressed -= Cube;
        //    behaviour.released -= Sphere;
        //}

        public void Cube()
        //private void Cube()
        {
            cube.SetActive(true);
            sphere.SetActive(false);
        }

        public void Sphere()
        //private void Sphere()
        {
            cube.SetActive(false);
            sphere.SetActive(true);
        }


    }
}