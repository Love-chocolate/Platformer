using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private Transform[] layer;
    [SerializeField] private Vector2[] coefficient; // Используйте Vector2 для коэффициентов параллакса по обеим осям

    private int layersCount;

    private void Start()
    {
        layersCount = layer.Length;
    }

    private void Update()
    {
        for (int i = 0; i < layersCount; i++)
        {
            Vector3 parallaxPos = new Vector3(transform.position.x * coefficient[i].x, transform.position.y * coefficient[i].y, layer[i].position.z);
            layer[i].position = parallaxPos;
        }
    }
}
