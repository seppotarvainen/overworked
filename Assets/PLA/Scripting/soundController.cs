using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    [SerializeField] private AudioClip ac_BGM;
    [SerializeField] private List<AudioClip> ac_SFX = new List<AudioClip>();
    [SerializeField] private List<AudioClip> ac_SFX_Rumbles = new List<AudioClip>();
    [SerializeField] private AudioSource ASGO_SFX;
    [SerializeField] private AudioSource ASGO_MUSIC;
    [SerializeField] private AudioSource ASGO_VOX;

    void Start()
    {
        ASGO_MUSIC.volume = 0.4f;
        ASGO_MUSIC.clip = ac_BGM;
        ASGO_MUSIC.Play();
    }

    public void PlaySFXOneshot(string sfxacName, float vol = 1.0f)
    {
        AudioClip acSFXItem;
        if (sfxacName == "rumble")
        {
            acSFXItem = ac_SFX_Rumbles[Random.Range(0, ac_SFX_Rumbles.Count)];
            ASGO_SFX.PlayOneShot(acSFXItem, vol);
        }
        else
        {
            for (int i = 0; i< ac_SFX.Count; i++)
            {
                if (ac_SFX[i].name == sfxacName)
                {
                    acSFXItem = ac_SFX[i];
                    ASGO_SFX.PlayOneShot(acSFXItem, vol);
                    break;
                }
            }
        }

    }

    public void PlayVOXOneshot(string voxName, float vol = 1.0f)
    {
        AudioClip acVOXItem;
        for (int i = 0; i< ac_SFX.Count; i++)
        {
            if(ac_SFX[i].name == voxName) {
                acVOXItem = ac_SFX[i];
                ASGO_VOX.PlayOneShot(acVOXItem, vol);
                break;
            }
        }
    }
}
