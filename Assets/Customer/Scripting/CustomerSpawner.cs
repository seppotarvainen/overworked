using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public float spawnInterval = 5;
    public GameObject customer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCustomers());
    }

    private IEnumerator SpawnCustomers()
    {
        while (GameManager.Instance.isGameRunning)
        {
            Instantiate(customer);
            customer.transform.position = transform.position;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
