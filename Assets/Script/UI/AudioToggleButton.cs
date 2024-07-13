using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggleButton : MonoBehaviour
{
    public Image buttonImage;
    public Sprite enableSprite;
    public Sprite disableSprite;

    private void Update()
    {
        if (AudioManager.instance.audioSource.enabled)
        {
            buttonImage.sprite = enableSprite;
        }
        else
        {
            buttonImage.sprite = disableSprite;
        }
    }

    public void ToggleAction()
    {
        AudioManager.instance.OnToggleValueChanged();
    }
}
