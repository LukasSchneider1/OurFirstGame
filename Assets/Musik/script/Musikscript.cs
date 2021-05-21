using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musikscript : MonoBehaviour
{
    public AudioSource Audiosource;
    public Slider volumeSlider;
    public float musicVolume = 1f;
   
   
    void Start()
    {
        Audiosource.Play();
        //laustärke wird aus dem String "volume" entnommen
        musicVolume = PlayerPrefs.GetFloat("volume");
        Audiosource.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        Audiosource.volume = musicVolume;
        //Die Werte der Varaiblen musicVolume wird in den String "volume" gesetzt
        PlayerPrefs.SetFloat("volume", musicVolume);
        
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
  
}


