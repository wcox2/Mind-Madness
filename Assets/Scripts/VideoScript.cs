using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{
    [SerializeField]
    VideoPlayer CutSceneVideoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        CutSceneVideoPlayer.loopPointReached += DoSomethingWhenVideoFinish;
        
    }

    void DoSomethingWhenVideoFinish(VideoPlayer vp)
    {
        Debug.Log("Video Ended");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
