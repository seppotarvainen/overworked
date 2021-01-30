using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subtaskScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void callItQuits()
    {
        gameObject.SetActive(false);
    }
    
    public void Completed()
    {
        gameObject.SetActive(false);
    }
}
