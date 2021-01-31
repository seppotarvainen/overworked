using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class nearbyOnlyClick : MonoBehaviour
{
    [SerializeField] private GameObject rendererGo;
    [SerializeField] private GameObject subtask;
    [SerializeField] private subtaskScript subtaskscr;
    [SerializeField] private soundController soundcontrol;
    [SerializeField] private bool iatask;
    [SerializeField] private string productName;

    public string GetProductName()
    {
        return productName;
    }
    
    private void OnTriggerEnter(Collider other)
    {

        bool isPlayer = other.GetComponentInParent<Player>() != null;

        if (!isPlayer) return;

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

        bool isPlayer = other.GetComponentInParent<Player>() != null;
        if (!isPlayer) return;

        gameObject.layer = 0;
        Destroy(rendererGo.GetComponent<Outline>());
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).tag == "storeitem")
            {
                gameObject.transform.GetChild(i).GetChild(0).gameObject.layer = 2;
            }
        }
        if (iatask && subtask.activeSelf)
        {
            subtaskscr.callItQuits();
        }
    }
}
