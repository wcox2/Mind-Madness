using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    //static Music instance;

    //// Drag in the .mp3 files here, in the editor
    //public AudioClip[] MusicClips;

    //public AudioSource Audio;

    //// Singelton to keep instance alive through all scenes
    //void Awake()
    //{
    //    if (instance == null) { instance = this; }
    //    else { Destroy(gameObject); }

    //    DontDestroyOnLoad(gameObject);

    //    // Hooks up the 'OnSceneLoaded' method to the sceneLoaded event
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //}

    //// Called whenever a scene is loaded
    //void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    //{
    //    // Replacement variable (doesn't change the original audio source)
    //    AudioSource source = new AudioSource();

    //    // Plays different music in different scenes
    //    switch (scene.name)
    //    {
    //        case "MainMenu":
    //            source.clip = MusicClips[0];
    //            break;
    //        case "LevelSelector":
    //            source.clip = MusicClips[0];
    //            break;
    //        case "LevelSelectorOccipital":
    //            source.clip = MusicClips[0];
    //            break;
    //        default:
    //            source.clip = MusicClips[1];
    //            break;
    //    }

    //    // Only switch the music if it changed
    //    if (source.clip != Audio.clip)
    //    {
    //        Audio.enabled = false;
    //        Audio.clip = source.clip;
    //        Audio.enabled = true;
    //    }
    //}
}
