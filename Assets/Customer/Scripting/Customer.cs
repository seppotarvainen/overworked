using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
  
    public string productName = "";

    private bool isProductFound = false;
    private Transform followed;
    private Animator animator;


    private float speed = 2f;
    private float turnSpeed = 5f;
    private float targetDistance = 1.5f;
    private ProductDisplay productDisplay;


    void Start()
    {
        // add +1 customer
        animator = GetComponentInChildren<Animator>();
        productDisplay = GetComponent<ProductDisplay>();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponentInParent<Player>();

        if (player == null)
            return;

        ShowRequiredProduct();

        FollowPlayer(player);
    }


    public void ShowRequiredProduct()
    {
        productDisplay.DisplayProduct();
        Debug.Log(productName);
    }

    private void FollowPlayer(Player player)
    {
        followed = player.transform;
        StartCoroutine(RunFollow());
    }

    public bool GiveProduct(string foundProduct) {
        isProductFound = productName.Equals(foundProduct);
        return isProductFound;
    }

    private IEnumerator RunFollow()
    {
        yield return new WaitForSeconds(1);
      
        while (followed != null)
        {
            Vector3 currentFollowPos = followed.transform.position + (Vector3.back * targetDistance);
            Vector3 diff = transform.position - currentFollowPos;

            if (diff.magnitude < 1)
            {
                animator.SetBool("isWalking", false);
            }
            else
            {
                animator.SetBool("isWalking", true);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentFollowPos - transform.position), Time.deltaTime * turnSpeed);
                transform.position += transform.forward * Time.deltaTime * speed;
            }
            
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }


}
