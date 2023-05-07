using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MemoryScript : MonoBehaviour
{
    public float amplitude = 1f; // Set the amplitude of the object's movement
    public float speed = 1f; // Set the speed of the object's movement
    public float rotationSpeed = 1f; // Set the speed of the object's rotation
    private Vector3 startPos; // Store the object's initial position
    public GameObject EndOfLevel;
    public GameObject UIHud;
    public GameController GameController;
    public Timer Timer;
    public PlayerMovement PlayerMovement;
    public GameObject CutScene;
    [SerializeField]
    VideoPlayer CutSceneVideoPlayer;



    void Start()
    {
        startPos = transform.position; // Set the object's initial position
        
    }


    void Update()
    {
        // Move the object up and down on a loop using a sine wave
        float y = startPos.y + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        // Rotate the object continuously
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter()
    {
        CutScene.SetActive(true);
        CutSceneVideoPlayer.loopPointReached += VideoFinish;
    }

    void VideoFinish(VideoPlayer pv) {
        Debug.Log("Video Ended");
        CutScene.SetActive(false);
        

        int stars = calculateStars();
        Time.timeScale = 0;
        EndOfLevel.SetActive(true);
        EndOfLevel.transform.GetChild(4).gameObject.SetActive(true);
        if (stars >= 2) {
            EndOfLevel.transform.GetChild(5).gameObject.SetActive(true);
        }
        if (stars == 3) {
            EndOfLevel.transform.GetChild(6).gameObject.SetActive(true);
        }
        UIHud.SetActive(false); 
        if (SceneManager.GetActiveScene().name == "TutorialLevel") {
            if (Global.numLevelsCompleted < 1) {
                Global.numLevelsCompleted = 1;
            }
            if (Global.tutorialStars < stars) {
                Global.tutorialStars = stars;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level1") {
            if (Global.numLevelsCompleted < 2) {
                Global.numLevelsCompleted = 2;
            }
            if (Global.level1Stars < stars) {
                Global.level1Stars = stars;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2") {
            if (Global.numLevelsCompleted < 3) {
                Global.numLevelsCompleted = 3;
            }
            if (Global.level2Stars < stars) {
                Global.level2Stars = stars;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level3") {
            if (Global.numLevelsCompleted < 4) {
                Global.numLevelsCompleted = 4;
            }
            if (Global.level3Stars < stars) {
                Global.level3Stars = stars;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level4") {
            if (Global.numLevelsCompleted < 5) {
                Global.numLevelsCompleted = 5;
            }
            if (Global.level4Stars < stars) {
                Global.level4Stars = stars;
            }
        }
    }

    int calculateStars() {
        int stars = 3;
        if (SceneManager.GetActiveScene().name == "Level4") {
            if (Timer.currentTime > 50) {
            stars--;
            }
            if (PlayerMovement.numDeaths > 3) {
                stars--;
            }
        }
        else {
            if (Timer.currentTime > 20) {
                stars--;
            }
            if (PlayerMovement.numDeaths > 0) {
            stars--;
        }
        }
        return stars;
    }
}
