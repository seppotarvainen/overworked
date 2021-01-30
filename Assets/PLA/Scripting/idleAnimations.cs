using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleAnimations : MonoBehaviour
{
    Animator animator;
    public bool canIdle = true;
    // Start is called before the first frame update
    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine("idleTimer");
    }

    IEnumerator idleTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(5.0f, 55.0f));
            gameObject.GetComponent<Animator>().SetTrigger("startIdle");
        }
    }
}
