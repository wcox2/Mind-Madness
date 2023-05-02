using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public bool isPaused = false;
    public GameObject UI;
    private GameObject pauseScreen;


    // Start is called before the first frame update
    void Start()
    {
        // pauseScreen = UI.transform.GetChild(4).gameObject;
        // UI = GameObject.Find("UI");
    }

    // Update is called once per frame
    void Update()
    {
        if (UI == null) {
            UI = GameObject.Find("UI");
        }
        if(Input.GetKeyDown(KeyCode.Escape) && (!isPaused)) {
            pauseGame();
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && (isPaused)) {
            unpauseGame();
        }
    }

    public void loadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        unpauseGame();
    }

    public void restartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        unpauseGame();
    }

    public void loadMainMenu() {
        SceneManager.LoadScene("HomeScreen");
        unpauseGame();
    }

    public void pauseGame() {
        // Debug.Log("Set Active Before");
        // pauseScreen.SetActive(true);
        // Debug.Log("Set Active After");
        isPaused = true;
        Time.timeScale = 0;
    }

    public void unpauseGame() {
        Time.timeScale = 1;
        isPaused = false;
        // Debug.Log("Set Inactive Before");
        // pauseScreen.SetActive(false);
        // Debug.Log("Set Inactive After");
    }
}
