using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public string nextLevel;
    public bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && (!isPaused)) {
            pauseGame();
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && (isPaused)) {
            unpauseGame();
        }
    }

    public void loadNextScene() {
        SceneManager.LoadScene(nextLevel);
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
        isPaused = true;
        Time.timeScale = 0;
    }

    public void unpauseGame() {
        Time.timeScale = 1;
        isPaused = false;
    }
}
