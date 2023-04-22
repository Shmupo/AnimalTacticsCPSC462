using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlide : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeVol()
    {
        AudioListener.volume = volumeSlider.value;
    }

    //we can still add player preferences to save this adjustment
}
