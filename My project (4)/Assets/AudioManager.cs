using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    private AudioSource musicSource;
    public AudioMixerGroup audioMixerGroup;  

    public AudioClip[] musicClips; // List of music clips

    // Ensure that there is only one instance of AudioManager
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this object when loading a new scene

            // Attach AudioSource to AudioManager
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.outputAudioMixerGroup = audioMixerGroup;
            // Set other AudioSource properties
            musicSource.loop = true;

            // Randomly choose and play a music clip
            if (musicClips.Length > 0)
            {
                AudioClip randomClip = musicClips[Random.Range(0, musicClips.Length)];
                musicSource.clip = randomClip;
                musicSource.Play();
            }
            else
            {
                Debug.LogError("No music clips assigned to AudioManager!");
            }
        }
        else
        {
            Destroy(gameObject); // Destroy any additional AudioManager instances
        }
        // Function to set the music volume
       

    }
  
}
