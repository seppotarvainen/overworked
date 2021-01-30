using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 playerVelocity;
    public float playerSpeed = 1.0f;
    public float sprintMul = 1.0f;
    private float gravityValue = -9.81f;
    private bool isMoving;

    Animator animator;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
    }


// movement ja animaatio loppuu kun tormataan seinaan (ei toimi)
/*     void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            rb.velocity = Vector3.zero;
            //Debug.Log("hit wall");
            animator.SetBool("isWalking", false);
        }
    } */

    void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float zMovement = Input.GetAxisRaw("Vertical");
        
        Vector3 move = new Vector3(xMovement, 0, zMovement).normalized;
        rb.velocity += move * (playerSpeed * sprintMul) * Time.deltaTime;


        Vector3 movementDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        if (movementDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDir.normalized), 0.1f);
        }

        bool isWalking = animator.GetBool("isWalking");
        if (!isWalking && (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0))
        {
            animator.SetBool("isWalking", true);
        }
        if (isWalking && (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)) 
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            sprintMul = 1.0f;
        }

        bool runPressed = Input.GetKey("left shift");
        bool isrunning = animator.GetBool("isRunning");
        if (!isrunning && (isWalking && runPressed))
        {
            animator.SetBool("isRunning", true);
            sprintMul = 2.0f;
        }

        if (isrunning && (!isWalking || !runPressed))
        {
            animator.SetBool("isRunning", false);
            sprintMul = 1.0f;
        }

    }
}
