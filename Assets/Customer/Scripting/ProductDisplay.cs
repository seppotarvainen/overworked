using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductDisplay : MonoBehaviour
{
    Transform objectToFollow;
    public float showtime = 2f;

    public Sprite speechBubble;

    RectTransform imageTransform;
    Image imageDisplay;
    public Vector3 offset = new Vector3(75, 200, 0);

    // RectTransform moodDisplay;
    // Start is called before the first frame update
    void Start()
    {
        objectToFollow = transform;
        imageDisplay = GetComponentInChildren<Canvas>()
            .GetComponentInChildren<Image>();
        imageTransform = GetComponentInChildren<Canvas>()
            .GetComponentInChildren<Image>()
            .rectTransform;

        imageDisplay.enabled = false;
        DisplayProduct();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 followPoint = Camera.main.WorldToScreenPoint(objectToFollow.transform.position);
        followPoint += offset;
        imageTransform.position = followPoint;
    }

    public void DisplayProduct()
    {
        if (!imageDisplay.enabled)
        {
            imageDisplay.enabled = true;
            imageDisplay.sprite = speechBubble;
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
        imageDisplay.enabled = false;
    }

}
