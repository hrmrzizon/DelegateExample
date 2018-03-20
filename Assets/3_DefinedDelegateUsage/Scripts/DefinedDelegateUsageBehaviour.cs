namespace Example.Delegate.DefinedUsage
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    using Random = UnityEngine.Random;

    [System.Serializable]
    public class FloatEvent : UnityEngine.Events.UnityEvent<float> { }

    public class DefinedDelegateUsageBehaviour : MonoBehaviour
    {
        [SerializeField]
        private string[] names;
        [SerializeField]
        private Material[] materials;
        [SerializeField]
        private Text[] texts;

        public FloatEvent floatEvent;

        private void Awake()
        {
            MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

            Array.ForEach(
                renderers,
                (MeshRenderer renderer) => // 생략가능
                {
                    int index = Random.Range(0, names.Length + 1);
                    renderer.name = index < names.Length ? names[index] : "None";

                    for (int i = 0; i < names.Length; i++)
                        if (renderer.name.ToLower().Contains(names[i].ToLower()))
                        {
                            renderer.material = materials[i];
                            break;
                        }
                }
                );

            int[] counts = new int[names.Length];

            Array.ForEach(
                renderers,
                (MeshRenderer renderer) =>
                {
                    for (int i = 0; i < names.Length; i++)
                        if (renderer.name.ToLower().Contains(names[i].ToLower()))
                        {
                            counts[i]++;
                            renderer.material = materials[i];
                            break;
                        }
                }
                );

            for (int i = 0; i < names.Length; i++)
            {
                MeshRenderer renderer = Array.Find(renderers, (otherrenderer) => otherrenderer.name.ToLower().Contains(names[i].ToLower()));
                renderer.material.color = renderer.material.color / 2;
                renderer = Array.FindLast(renderers, (otherrenderer) => otherrenderer.name.ToLower().Contains(names[i].ToLower()));
                renderer.material.color = renderer.material.color / 2;
            }

            for (int i = 0; i < counts.Length; i++)
                texts[i].text = string.Format("{0}:{1}", names[i][0], counts[i]);
        }
    }
}