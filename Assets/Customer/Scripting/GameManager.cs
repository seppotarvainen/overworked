using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isGameRunning = true;

    private int maxCustomerCount = 30;
    private int timeInit = 180;
    private int timeRemaining;
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
            Init();
        }
    }

    private void Init()
    {
        StopAllCoroutines();
        timeRemaining = timeInit;
        StartCoroutine(RunTimer());
    }

    private void Reset()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.R))
        {
            Reset();
        }
    }

    public void AddCustomer()
    {
        customerCount++;
        UIManager.OnUpdateCustomers += () => new int[]{ customerCount, maxCustomerCount};

        if (customerCount >= maxCustomerCount)
        {
            Reset();
        }
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

    public IEnumerator RunTimer()
    {
        while (timeRemaining > 0)
        {
            UIManager.OnUpdateTimer += () => timeRemaining;
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }

        Debug.Log("Voitto");
        Reset();
    }

}
