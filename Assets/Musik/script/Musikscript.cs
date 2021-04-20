using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musikscript : MonoBehaviour
{
    public AudioSource Audiosource;
    public Slider volumeSlider;
    public float musicVolume = 1f;
   
    // Start is called before the first frame update
    void Start()
    {
        Audiosource.Play();
        musicVolume = PlayerPrefs.GetFloat("volume");
        Audiosource.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        Audiosource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
        
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
  
}


