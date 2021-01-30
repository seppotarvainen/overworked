using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> storeShelves = new List<GameObject>();
    private string prodName;
    private Texture prodSprite;

    public List<GameObject> spawnedItems = new List<GameObject>();

    Renderer m_Renderer;

    void Start()
    {
        foreach (GameObject obj in storeShelves)
        {
            prodName = ProductService.Instance.GetRandomProduct().productName;
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
