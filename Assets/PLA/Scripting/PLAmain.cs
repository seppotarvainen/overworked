using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAmain : MonoBehaviour
{

    public GameObject SubtaskModal;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit && hitInfo.transform.gameObject.tag == "interactable") 
            {
                SubtaskModal.SetActive(true);
            }
        } 
    }
}
