using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public float spawnInterval = 60;
    public GameObject customer;
    GameObject[] shelfArray;

    private List<Vector3> shelfPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        shelfArray = GameObject.FindGameObjectsWithTag("shelf");
        foreach(GameObject shelf in shelfArray)
        {
            shelfPositions.Add(shelf.transform.position + (shelf.transform.forward * 1.25f));
        }

        StartCoroutine(SpawnCustomers());
    }


    private IEnumerator SpawnCustomers()
    {
        while (GameManager.Instance.isGameRunning)
        {
            GameObject newCustomer = Instantiate(customer);
            newCustomer.transform.position = transform.position;
            Customer customerScript = newCustomer.GetComponent<Customer>();
            customerScript.SetShelfPositions(shelfPositions);
           

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
