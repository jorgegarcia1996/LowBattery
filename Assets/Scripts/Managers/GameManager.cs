using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region ##### VARIABLES #####
    public GameObject inGameHud;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    public CameraController mainCamera;
    public PlayerControler player;

    public bool paused;

    public static GameManager instance;
    #endregion
    #region ##### EVENTS #####
    void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Pause(!paused);
        }
    }

    #endregion
    #region ##### METHODS #####

    /// <summary>
    /// 
    /// </summary>
    public void Pause(bool pause) {
        if (pause) {
            pauseMenu.SetActive(true);
            inGameHud.SetActive(false);
            mainCamera.enabled = false;
            player.enabled = false;
            Time.timeScale = 0f;
            paused = true;
        }
        else {
            pauseMenu.SetActive(false);
            inGameHud.SetActive(true);
            mainCamera.enabled = true;
            player.enabled = true;
            Time.timeScale = 1f;
            paused = false;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void RestartLevel() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// Game Over Menu
    /// </summary>
    public void GameOver() {
        inGameHud.SetActive(false);
        gameOverMenu.SetActive(true);
        gameOverMenu.transform.Find("GameOverMenu").gameObject.SetActive(true);
    }

    public void SetMouseSensibility(float sensitivity) {
        mainCamera.mouseSensitivity = sensitivity;
        
    }
    #endregion
}
