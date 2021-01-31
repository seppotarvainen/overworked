using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text customerCount;
    public Text timer;

    public delegate int[] UpdateUI();
    public static event UpdateUI OnUpdateCustomers;

    public delegate int UpdateTimerUI();
    public static event UpdateTimerUI OnUpdateTimer;

    private void Update()
    {
        if (OnUpdateCustomers != null)
        {
            int[] currentAndMax = OnUpdateCustomers();
            UpdateCustomerCount(currentAndMax[0], currentAndMax[1]);
            OnUpdateCustomers = null;
        }

        if (OnUpdateTimer != null)
        {
            int val = OnUpdateTimer();
            UpdateTimer(val);
            OnUpdateTimer = null;
        }
    }


    public void UpdateCustomerCount(int current, int max)
    {
        customerCount.text = string.Format("Customers {0}/{1}", current, max);
    }

    public void UpdateTimer(int currentTime)
    {
        int minutes = currentTime / 60;
        int seconds = currentTime % 60;

        timer.text = string.Format("Time remaining: {0}:{1:D2}", minutes, seconds);
    }
}
