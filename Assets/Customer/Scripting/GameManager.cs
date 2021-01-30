using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isGameRunning = true;

    private int maxCustomerCount = 30;
    private int customerCount;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddCustomer()
    {
        customerCount++;
        UIManager.OnUpdateCustomers += () => new int[]{ customerCount, maxCustomerCount};
    }

    public void RemoveCustomer()
    {
        customerCount--;
        UIManager.OnUpdateCustomers += () => new int[] { customerCount, maxCustomerCount };
    }

    public void ClearData()
    {
        customerCount = 0;
    }
}
