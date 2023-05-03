using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {
    public GameController GameController;



    void Update() {
        if (SceneManager.GetActiveScene().name == "LevelSelector") {
            if (Global.numLevelsCompleted > 0) { // unlock Occipital
                this.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
            }

            if (Global.numLevelsCompleted > 4) { // unlock Temporal
                this.transform.GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(false);
            }

            if (Global.numLevelsCompleted > 8) { // unlock Parietal
                this.transform.GetChild(0).GetChild(3).GetChild(1).gameObject.SetActive(false);
            }

            if (Global.numLevelsCompleted > 12) { // unlock Frontal
                this.transform.GetChild(0).GetChild(4).GetChild(1).gameObject.SetActive(false);
            }

            if (Global.tutorialStars > 0) {
                this.transform.GetChild(0).GetChild(6).GetChild(1).gameObject.SetActive(true); // tutorial star 1
            }
            if (Global.tutorialStars > 1) {
                this.transform.GetChild(0).GetChild(6).GetChild(2).gameObject.SetActive(true); // tutorial star 2
            }
            if (Global.tutorialStars > 2) {
                this.transform.GetChild(0).GetChild(6).GetChild(3).gameObject.SetActive(true); // tutorial star 3
            }
        }

        else if (SceneManager.GetActiveScene().name == "LevelSelectorOccipital") {
            if (Global.numLevelsCompleted > 0) { // unlock level 1
                this.transform.GetChild(0).GetChild(1).GetChild(1).gameObject.SetActive(false);
            }

            if (Global.numLevelsCompleted > 1) { // unlock level 2
                this.transform.GetChild(0).GetChild(2).GetChild(1).gameObject.SetActive(false);
            }

            if (Global.numLevelsCompleted > 2) { // unlock level 3
                this.transform.GetChild(0).GetChild(3).GetChild(1).gameObject.SetActive(false);
            }

            if (Global.numLevelsCompleted > 3) { // unlock level 4
                this.transform.GetChild(0).GetChild(4).GetChild(1).gameObject.SetActive(false);
            }

            // Level 1 stars
            if (Global.level1Stars > 0) {
                this.transform.GetChild(0).GetChild(1).GetChild(2).gameObject.SetActive(true); // level 1 star 1
            }
            if (Global.level1Stars > 1) {
                this.transform.GetChild(0).GetChild(1).GetChild(3).gameObject.SetActive(true); // level 1 star 2
            }
            if (Global.level1Stars > 2) {
                this.transform.GetChild(0).GetChild(1).GetChild(4).gameObject.SetActive(true); // level 1 star 3
            }

            // Level 2 stars
            if (Global.level2Stars > 0) {
                this.transform.GetChild(0).GetChild(2).GetChild(2).gameObject.SetActive(true); // level 2 star 1
            }
            if (Global.level2Stars > 1) {
                this.transform.GetChild(0).GetChild(2).GetChild(3).gameObject.SetActive(true); // level 2 star 2
            }
            if (Global.level2Stars > 2) {
                this.transform.GetChild(0).GetChild(2).GetChild(4).gameObject.SetActive(true); // level 2 star 3
            }

            // Level 3 stars
            if (Global.level3Stars > 0) {
                this.transform.GetChild(0).GetChild(3).GetChild(2).gameObject.SetActive(true); // level 3 star 1
            }
            if (Global.level3Stars > 1) {
                this.transform.GetChild(0).GetChild(3).GetChild(3).gameObject.SetActive(true); // level 3 star 2
            }
            if (Global.level3Stars > 2) {
                this.transform.GetChild(0).GetChild(3).GetChild(4).gameObject.SetActive(true); // level 3 star 3
            }

            // Level 3 stars
            if (Global.level4Stars > 0) {
                this.transform.GetChild(0).GetChild(4).GetChild(2).gameObject.SetActive(true); // level 4 star 1
            }
            if (Global.level4Stars > 1) {
                this.transform.GetChild(0).GetChild(4).GetChild(3).gameObject.SetActive(true); // level 4 star 2
            }
            if (Global.level4Stars > 2) {
                this.transform.GetChild(0).GetChild(4).GetChild(4).gameObject.SetActive(true); // level 4 star 3
            }
        }
    }

    public void LoadTutorial() {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void LoadFrontal()
    {
        if (Global.numLevelsCompleted > 12) {
            SceneManager.LoadScene("LevelSelectorFrontal");
        }
    }

    public void LoadTemporal()
    {
        if (Global.numLevelsCompleted > 4) {
            SceneManager.LoadScene("LevelSelectorTemporal");
        }
    }

    public void LoadParietal()
    {
        if (Global.numLevelsCompleted > 8) {
            SceneManager.LoadScene("LevelSelectorParietal");
        }
    }

    public void LoadOccipital()
    {
        if (Global.numLevelsCompleted > 0) {
            SceneManager.LoadScene("LevelSelectorOccipital");
        }
    }

    public void LoadLevel1() {
        if (Global.numLevelsCompleted > 0) {
            SceneManager.LoadScene("Level1");
        }
    }

    public void LoadLevel2() {
        if (Global.numLevelsCompleted > 1) {
            SceneManager.LoadScene("Level2");
        }
    }

    public void LoadLevel3() {
        if (Global.numLevelsCompleted > 2) {
            SceneManager.LoadScene("Level3");
        }
    }

    public void LoadLevel4() {
        if (Global.numLevelsCompleted > 3) {
            SceneManager.LoadScene("Level4");
        }
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void LoadHomeScreen() {
        SceneManager.LoadScene("HomeScreen");
    }

    public void Play() {
        if (Global.numLevelsCompleted == 0) {
            SceneManager.LoadScene("TutorialLevel");
        }
        else {
            SceneManager.LoadScene("LevelSelector");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
