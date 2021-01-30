using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    public Product product;

    private bool isProductFound = false;
    private Transform followed;
    private Animator animator;

    private float targetDistance = 1.5f;
    private ProductDisplay productDisplay;
    private NavMeshAgent agent;

    private Vector3 exitPosition;
    private List<Vector3> shelfPositions;
    private int prevShelfPosIndex = -1;

    void Start()
    {
        GameManager.Instance.AddCustomer();
        exitPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponentInChildren<Animator>();
        productDisplay = GetComponent<ProductDisplay>();
        product = ProductService.Instance.GetRandomProduct();

        StartCoroutine(RunWalkFreely());
    }

    public void SetShelfPositions(List<Vector3> positions)
    {
        shelfPositions = positions;
    }

    private Vector3 GetRandomShelfPosition()
    {
        if (shelfPositions.Count == 1)
        {
            return shelfPositions[0];
        }

        int newIndex = Random.Range(0, shelfPositions.Count);
        while (prevShelfPosIndex == newIndex)
        {
            newIndex = Random.Range(0, shelfPositions.Count);
        }

        prevShelfPosIndex = newIndex;
        return shelfPositions[newIndex];
    }

    public void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponentInParent<Player>();

        if (player == null)
            return;

        if (IsCorrectProduct(player.GetProduct()) && !isProductFound)
        {
            StopAllCoroutines();
            followed = null;
            isProductFound = true;
            StartCoroutine(WalkToExit());
        }
        else if(!isProductFound)
        {
            ShowRequiredProduct();

            if (followed == null)
            {
                FollowPlayer(player);
            }
        }
        else
        {
            Debug.Log("Kiitosta vaan!");
        }
    }


    public void ShowRequiredProduct()
    {
        productDisplay.DisplayProduct(product);
    }

    private void FollowPlayer(Player player)
    {
        Debug.Log("Start follow!");
        StopAllCoroutines();
        followed = player.transform;
        StartCoroutine(RunFollow());
    }

    public bool IsCorrectProduct(Product foundProduct) {

        if (foundProduct == null)
            return false;

        return product.productName.Equals(foundProduct.productName);
    }

    private IEnumerator WalkToExit()
    {
        agent.destination = exitPosition;
        float diff = 10;
        animator.SetBool("isWalking", true);

        while (diff >= agent.stoppingDistance)
        {
            diff = (transform.position - agent.destination).magnitude;
            yield return null;
        }

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private IEnumerator RunWalkFreely()
    {
        yield return new WaitForSeconds(1);

        agent.destination = GetRandomShelfPosition();
        animator.SetBool("isWalking", true);

        while (followed == null)
        {
            Vector3 diff = transform.position - agent.destination;

            if (diff.magnitude <= agent.stoppingDistance)
            {
                animator.SetBool("isWalking", false);
                agent.isStopped = true;
                yield return null;
                yield return new WaitForSeconds(1);

                agent.destination = GetRandomShelfPosition();
                agent.isStopped = false;
                animator.SetBool("isWalking", true);
            }
            yield return null;
        }
    }

    private IEnumerator RunFollow()
    {
        agent.destination = transform.position;
        yield return new WaitForSeconds(1);
      
        while (followed != null)
        {
            Vector3 currentFollowPos = followed.transform.position + (Vector3.back * targetDistance);
            Vector3 diff = transform.position - currentFollowPos;

            if (diff.magnitude <= agent.stoppingDistance)
            {
                animator.SetBool("isWalking", false);
            }
            else
            {
                agent.destination = currentFollowPos;
                animator.SetBool("isWalking", true);
                yield return new WaitForSeconds(0.1f);
            }
            
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }


}
