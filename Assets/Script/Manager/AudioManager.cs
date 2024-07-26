using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioClip[] soundEffects;
    private bool isMute;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySound(int i)
    {
        if (audioSource.enabled)
        {
            audioSource.PlayOneShot(soundEffects[i]);
        }
    }

    public void SetSound(float f)
    {
        if (audioSource.enabled)
        {
            audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
            audioSource.volume = f;
        }
    }

    public void OnToggleValueChanged()
    {
        if (!isMute)
        {
            isMute = true;

            if (audioSource.enabled)
            {
                audioSource.enabled = false;
            }
            else
            {
                audioSource.enabled = true;
            }
        }

        isMute = false;
    }
}
