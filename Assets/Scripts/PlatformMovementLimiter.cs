using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementLimiter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            collision.GetComponent<PlatformMovement>().ChangePlatformDirection();
        }
    }
}
