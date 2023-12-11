using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowCamera : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform; // Получаем компонент Transform главной камеры
    }

    void LateUpdate()
    {
        Vector3 newPos = transform.position; // Получаем текущую позицию заднего фона
        newPos.y = cameraTransform.position.y; // Привязываем вертикальную позицию камеры к вертикальной позиции заднего фона
        transform.position = newPos; // Устанавливаем новую позицию заднего фона
    }
}
