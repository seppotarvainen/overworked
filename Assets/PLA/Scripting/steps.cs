using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steps : MonoBehaviour
{
    [SerializeField] private soundController soundcontrol;

    private void Start()
    {
        if (soundcontrol == null)
        {
            soundcontrol = GameObject.FindGameObjectWithTag("soundcontroller").GetComponent<soundController>();
        }
    }

    private void footstep()
    {
        soundcontrol.PlayFSOneshot();
    }
}
