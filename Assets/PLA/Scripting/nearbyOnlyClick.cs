using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class nearbyOnlyClick : MonoBehaviour
{
    [SerializeField] private GameObject rendererGo;
    
    private void OnTriggerEnter(Collider other)
    {
        gameObject.layer = 2;
        rendererGo.AddComponent<Outline>();
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.layer = 0;
        Destroy(rendererGo.GetComponent<Outline>());
    }
}
