using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private string prodName;
    private Texture prodSprite;

    public List<GameObject> spawnedItems = new List<GameObject>();

    private List<nearbyOnlyClick> clickableShelves = new List<nearbyOnlyClick>();

    Renderer m_Renderer;

    void Start()
    {
        clickableShelves = new List<nearbyOnlyClick>(GetComponentsInChildren<nearbyOnlyClick>());

        foreach (nearbyOnlyClick shelf in clickableShelves)
        {
            GameObject obj = shelf.gameObject;

            prodName = shelf.GetProductName() != "" ?
                shelf.GetProductName() :
                ProductService.Instance.GetRandomProduct().productName;

            prodSprite = ProductService.Instance.GetProduct(prodName).image.texture;
            
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                if (obj.transform.GetChild(i).tag == "storeitem")
                {
                    obj.transform.GetChild(i).name = prodName;
                    spawnedItems.Add(obj.transform.GetChild(i).gameObject);
                }

                if (obj.transform.GetChild(i).name == "ItemSprite")
                {
                    m_Renderer = obj.transform.GetChild(i).gameObject.GetComponent<Renderer> ();
                    m_Renderer.material.SetTexture("_MainTex", prodSprite);
                }
            }
        }
    }
}
