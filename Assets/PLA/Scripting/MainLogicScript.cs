using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogicScript : MonoBehaviour
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
            if (hit && hitInfo.transform.gameObject.tag == "storeitem") 
            {
                Debug.Log("picked up item "+hitInfo.transform.gameObject.transform.parent.name);
                hitInfo.transform.gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
