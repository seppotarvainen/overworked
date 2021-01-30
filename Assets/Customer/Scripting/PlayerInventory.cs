using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private Product productInHand;
    

    // Start is called before the first frame update
    void SetProduct(Product product)
    {
        productInHand = product;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
