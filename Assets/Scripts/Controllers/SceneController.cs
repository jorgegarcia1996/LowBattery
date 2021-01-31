using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region EVENTS
    public Animator fadeToBlack;

    #endregion




    #region  ##############  METHODS  ##############
    public void ChangeScene(string sceneName) {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }



    public void StartGame() {
        StartCoroutine(FadeStart(5f));

    }

    IEnumerator FadeStart(float delayTime) {

        fadeToBlack.SetTrigger("Trigger");
        yield return new WaitForSeconds(delayTime);
        ChangeScene("Game");
    }

    public void ExitGame() {
        Application.Quit();
    }
    #endregion
}
