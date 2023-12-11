using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    public bool isGrounded;

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private bool jump;

    private void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
        playerRigidbody = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (jump == true)
        {
            animator.SetTrigger("isJumped");
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
        }

        if (playerRigidbody.velocity.y < 0 && isGrounded == false)
        {
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }
    }

}
