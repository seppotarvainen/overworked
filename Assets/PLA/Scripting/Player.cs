using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    private Vector3 playerVelocity;
    public float playerSpeed = 16.0f;
    public float sprintMul = 1.0f;
    private bool isMoving;
    private Product product;

    Animator animator;

    [SerializeField] private GameObject selectedPlayermodel;

    void Awake()
    {
        StartCoroutine("idleTimer");
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = selectedPlayermodel.GetComponent<Animator>();
    }

    IEnumerator idleTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 15.0f));
            if (!isMoving)
                animator.SetTrigger("startIdle");
        }
    }

    public void SetProduct(string productName)
    {
        product = ProductService.Instance.GetProduct(productName);
        Debug.Log("Product set " + product.productName);
    }

    public Product GetProduct()
    {
        if (product != null)
        {
            Debug.Log("Product get " + product.productName);
        }
        
        return product;
    }

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
            isMoving = true;
        }
        if (isWalking && (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)) 
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            isMoving = false;
            sprintMul = 1.0f;
        }

        bool runPressed = Input.GetButton("Fire3");
        bool isrunning = animator.GetBool("isRunning");
        if (!isrunning && (isWalking && runPressed))
        {
            animator.SetBool("isRunning", true);
            sprintMul = 3.0f;
        }

        if (isrunning && (!isWalking || !runPressed))
        {
            animator.SetBool("isRunning", false);
            sprintMul = 1.0f;
        }

    }
}
