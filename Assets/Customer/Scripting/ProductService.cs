using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductService : MonoBehaviour
{
    public static ProductService Instance { get; private set; }

    public List<Product> products;

    private Dictionary<string, Product> productDict = new Dictionary<string, Product>();
    private List<String> productNames = new List<string>();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            InitData();
        }
    }

    // Start is called before the first frame update
    void InitData()
    {
        products.ForEach(p => {
            productDict.Add(p.productName, p);
            productNames.Add(p.productName);
        });
    }

    public Product GetRandomProduct()
    {
        string randProduct = productNames[UnityEngine.Random.Range(0, productNames.Count)];
        return GetProduct(randProduct);
    }

    public Product GetProduct(string name)
    {
        return productDict[name];
    }
}

[Serializable]
public class Product
{
    public Sprite image;
    public string productName;
}
