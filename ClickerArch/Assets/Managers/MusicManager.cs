using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;

    public static string playingAudioID;

    public static MusicManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<MusicManager>();

                //Tell unity not to destroy this object when loading a new scene!
                if (_instance != null)
                {
                    DontDestroyOnLoad(_instance.gameObject);
                }
                else
                {
                    Debug.LogWarning("Dont find instance!");
                }
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != _instance)
                Destroy(this.gameObject);
        }
    }

    public void Play(string id, AudioClip audioClip)
    {
        if(playingAudioID != id)
        {
            var audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
            playingAudioID = id;
        }
        
    }

    public void Stop()
    {
        var audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Stop();
    }

}