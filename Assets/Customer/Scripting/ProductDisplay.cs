using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductDisplay : MonoBehaviour
{
    Transform objectToFollow;
    public float showtime = 5f;

    public Image imageDisplay;

    RectTransform imageContainer;

    public Vector3 offset = new Vector3(75, 200, 0);

    // RectTransform moodDisplay;
    // Start is called before the first frame update
    void Start()
    {
        objectToFollow = transform;
        imageContainer = GetComponentInChildren<Canvas>()
            .GetComponentInChildren<Image>()
            .rectTransform;
        
        imageContainer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 followPoint = Camera.main.WorldToScreenPoint(objectToFollow.transform.position);
        followPoint += offset;
        imageContainer.position = followPoint;
    }

    public void DisplayProduct(Product product)
    {
        if (!imageContainer.gameObject.activeSelf)
        {
            Debug.Log(product.productName);
            imageContainer.gameObject.SetActive(true);
            imageDisplay.sprite = product.image;
            StartCoroutine(ShowProduct());
        }
    }

    IEnumerator ShowProduct()
    {
        float endTime = Time.time + showtime;
        while (Time.time < endTime)
        {
            yield return null;
        }
        imageContainer.gameObject.SetActive(false);
    }

}
