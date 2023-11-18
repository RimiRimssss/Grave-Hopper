using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicSliderVolume : MonoBehaviour
{
    //reference to audio source component
    private AudioSource audioSrc;

    //music volume variable that will be modified by dragging slider knob
    private float musicVolume = 1f;

    // Use this for initialization
    void Start()
    {
        //assign audio source component to control it
        audioSrc = GetComponent<AudioSource>();
    }
    // update is acalled once per frame
    void Update()
    {
        //setting volume option of audio source to be equal to musicVolume
        audioSrc.volume = musicVolume;
    }

    //method that is called by slider game object
    //this method takes vol value passed by slider
    //and sets it as musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
