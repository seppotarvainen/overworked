using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductDisplay : MonoBehaviour
{
    Transform objectToFollow;
    public float showtime = 5f;

    public Sprite product;

    RectTransform imageContainer;
    Image imageDisplay;

    public Vector3 offset = new Vector3(75, 200, 0);

    // RectTransform moodDisplay;
    // Start is called before the first frame update
    void Start()
    {
        objectToFollow = transform;
        imageDisplay = GetComponentInChildren<Canvas>()
            .GetComponentInChildren<Image>()
            .GetComponentsInChildren<Image>()[0];
        imageContainer = GetComponentInChildren<Canvas>()
            .GetComponentInChildren<Image>()
            .rectTransform;
        
        imageContainer.gameObject.SetActive(false);
        DisplayProduct();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 followPoint = Camera.main.WorldToScreenPoint(objectToFollow.transform.position);
        followPoint += offset;
        imageContainer.position = followPoint;
    }

    public void DisplayProduct()
    {
        if (!imageContainer.gameObject.activeSelf)
        {
            imageContainer.gameObject.SetActive(true);
            imageDisplay.sprite = product;
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
