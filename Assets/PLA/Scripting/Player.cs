using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 playerVelocity;
    private float playerSpeed = 1.0f;
    private float gravityValue = -9.81f;
    private bool isMoving;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {

/*         if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * playerSpeed);
            rb.velocity += transform.right * Input.GetAxisRaw("Horizontal") * (Time.deltaTime * playerSpeed);
            isMoving = true;
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * playerSpeed);
            rb.velocity += transform.forward * Input.GetAxisRaw("Vertical") * (Time.deltaTime * playerSpeed);
            isMoving = true;
        } */


        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity += move * Time.deltaTime * playerSpeed;
        //controller.Move(move * Time.deltaTime * playerSpeed);

        //playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);



    }
}
