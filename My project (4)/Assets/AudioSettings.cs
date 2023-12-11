using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AudioSettings : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider carVolumeSlider;

    public AudioMixer audioMixer;

    private void Start()
    {
        // Ensure AudioManager is set in the Inspector
       

        // Set listener functions for the sliders
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        carVolumeSlider.onValueChanged.AddListener(SetCarVolume);

        carVolumeSlider.value = PlayerPrefs.GetFloat("CarVolume", 0);
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MainVolume", 0);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);
    }

    // Functions to be called when sliders are manipulated
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    // Function to set the music volume
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    // Function to set the car volume
    public void SetCarVolume(float volume)
    {
        audioMixer.SetFloat("CarVolume", volume);
    }
    public void Back()
    {
        // Load the "GameScene" when the Start button is pressed.
        SceneManager.LoadScene("Settings");
        PlayerPrefs.SetFloat("CarVolume", carVolumeSlider.value); 
        PlayerPrefs.SetFloat("MainVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);

    }
}
