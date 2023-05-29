using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite SoundOffSprite, SoundOnSprite;
    public Image SoundButtonImage;

    private void Start()
    {
        if (AudioListener.pause)
        {
            SoundButtonImage.sprite = SoundOffSprite;
        }
        else if (!AudioListener.pause)
        {
            SoundButtonImage.sprite = SoundOnSprite;
        }
    }
    
    public void OnSoundButtonClicked()
    {
        AudioListener.pause = !AudioListener.pause;
        if (AudioListener.pause)
        {
            SoundButtonImage.sprite = SoundOffSprite;
        }
        else if (!AudioListener.pause)
        {
            SoundButtonImage.sprite = SoundOnSprite;
        }
    }
}
