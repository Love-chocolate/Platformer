using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowCamera : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform; // �������� ��������� Transform ������� ������
    }

    void LateUpdate()
    {
        Vector3 newPos = transform.position; // �������� ������� ������� ������� ����
        newPos.y = cameraTransform.position.y; // ����������� ������������ ������� ������ � ������������ ������� ������� ����
        transform.position = newPos; // ������������� ����� ������� ������� ����
    }
}
