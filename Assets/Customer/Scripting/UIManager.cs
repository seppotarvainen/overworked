using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text customerCount;

    public delegate int[] UpdateUI();
    public static event UpdateUI OnUpdateCustomers;

    private void Update()
    {
        if (OnUpdateCustomers != null)
        {
            int[] currentAndMax = OnUpdateCustomers();
            UpdateCustomerCount(currentAndMax[0], currentAndMax[1]);
            OnUpdateCustomers = null;
        }
    }


    public void UpdateCustomerCount(int current, int max)
    {
        customerCount.text = string.Format("Customers {0}/{1}", current, max);
    }
}
