using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subtaskScript : MonoBehaviour
{
    [SerializeField] private soundController soundcontrol;

    public void callItQuits()
    {
        soundcontrol.PlaySFXOneshot("sfx-close");
        gameObject.SetActive(false);
    }
    
    public void Completed()
    {
        soundcontrol.PlaySFXOneshot("sfx-tada");
        gameObject.SetActive(false);
    }

}
