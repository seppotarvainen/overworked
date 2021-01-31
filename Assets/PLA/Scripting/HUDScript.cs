using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    [SerializeField] private soundController soundcontrol;
    [SerializeField] private GameObject settings;

    public void openMenu()
    {
        soundcontrol.PlaySFXOneshot("sfx-open");
        settings.SetActive(true);
    }

    public void callItQuits()
    {
        soundcontrol.PlaySFXOneshot("sfx-close");
        settings.SetActive(false);
    }
}
