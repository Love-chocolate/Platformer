using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFallPlatformHandler : MonoBehaviour
{
    [SerializeField] private bool isMoving;

    private Transform currentPlatform;
    private Vector3 playerOffset;
    private bool checkPlatform;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            if(checkPlatform == true)
            {
                currentPlatform = collision.transform;
                playerOffset = transform.position - collision.transform.position;
                checkPlatform = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))
        {
            isMoving = true;
            currentPlatform = null;
        }
        else
        {
            isMoving = false;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.Space))
        {
            checkPlatform = true;
        }

        if (currentPlatform != null && isMoving == false)
        {
            transform.position = currentPlatform.position + playerOffset;
        }
    }
}
