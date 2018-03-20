namespace Example.Delegate.Usage
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

        private void OnEnable()
        {
            behaviour.pressed += Cube;
            behaviour.released += Sphere;
        }

        private void OnDisable()
        {
            behaviour.pressed -= Cube;
            behaviour.released -= Sphere;
        }

        private void Cube()
        {
            cube.SetActive(true);
            sphere.SetActive(false);
        }

        private void Sphere()
        {
            cube.SetActive(false);
            sphere.SetActive(true);
        }


    }
}