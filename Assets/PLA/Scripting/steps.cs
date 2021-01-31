using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steps : MonoBehaviour
{
    [SerializeField] private soundController soundcontrol;

    private void footstep()
    {
        soundcontrol.PlayFSOneshot();
    }
}
