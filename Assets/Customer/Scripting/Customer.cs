using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
  
    public string productName = "";
    private bool isProductFound = false;


    void Start()
    {
        // add +1 customer
    }

    void Update()
    {
        // eli asiakas ossaa kysyä tuotetta, sillä lähtee timeri pyörimään, lisään metodit ajan loppumiseen ja tavaran löytymiseen.
    }

    public void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponentInParent<Player>();

        if (player == null)
            return;

        ShowRequiredProduct();
    }

    public void ShowRequiredProduct()
    {
        Debug.Log(productName);
    }

    public bool GiveProduct(string foundProduct) {
        isProductFound = productName.Equals(foundProduct);
        return isProductFound;
    }

}
