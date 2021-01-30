using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angy : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("shopper is angy");
            animator.SetBool("isAngy", true);
        }
    }
}
