using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    

    #region  ##############  METHODS  ##############
    public string sceneName;

    /// <summary>
    /// Cambia la escena recibida como parametro
    /// </summary>
    /// <param name="sceneName"></param>
    public void ChangeScene(string sceneName) {
        // restauramos la escala de tiempo default
        Time.timeScale = 1f;
        // cargamos la escena
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Cerrar el ejecutable del juego
    /// </summary>
    public void ExitGame() {
        // cierra la aplicación
        Application.Quit();
    }
    #endregion
}
