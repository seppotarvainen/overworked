using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class nearbyOnlyClick : MonoBehaviour
{
    [SerializeField] private GameObject rendererGo;
    [SerializeField] private GameObject subtask;
    
    private void OnTriggerEnter(Collider other)
    {
        gameObject.layer = 2;
        rendererGo.AddComponent<Outline>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).tag == "storeitem")
            {
                gameObject.transform.GetChild(i).GetChild(0).gameObject.layer = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.layer = 0;
        Destroy(rendererGo.GetComponent<Outline>());
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).tag == "storeitem")
            {
                gameObject.transform.GetChild(i).GetChild(0).gameObject.layer = 2;
            }
        }
        if (subtask != null)
        {
            subtask.SetActive(false);
        }
    }
}
