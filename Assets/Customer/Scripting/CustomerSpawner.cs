using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public float spawnInterval = 60;
    public GameObject[] customers;
    GameObject[] shelfArray;

    private List<Vector3> shelfPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCustomers());
    }

    private GameObject GetRandomCustomer()
    {
        return customers[Random.Range(0, customers.Length + 1)];
    }


    private IEnumerator SpawnCustomers()
    {
        yield return new WaitForSeconds(1);
        shelfArray = GameObject.FindGameObjectsWithTag("shelf");
        foreach (GameObject shelf in shelfArray)
        {
            Vector3 pos = shelf.transform.position;
            pos.y = 1;
            Debug.Log(pos);

            shelfPositions.Add(pos);
        }

        while (GameManager.Instance.isGameRunning)
        {
            GameObject newCustomer = Instantiate(GetRandomCustomer());
            newCustomer.transform.position = transform.position;
            Customer customerScript = newCustomer.GetComponent<Customer>();
            customerScript.SetShelfPositions(shelfPositions);
           

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
