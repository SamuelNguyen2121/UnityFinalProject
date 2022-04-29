using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField]
    private Toggle mute;

    [SerializeField]
    private Slider volumeSlider;

    public void muteMusic()
    {
        if (mute.GetComponent<Toggle>().isOn)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

    public void changeSound()
    {
        if (mute.GetComponent<Toggle>().isOn)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = volumeSlider.value;
        }
    }
}
