using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region ##### VARIABLES #####

    public static GameManager instance;
    #endregion

    #region ##### EVENTS #####
    void Start() {
        if (instance == null) {
            instance = this;
        }
    }

    #endregion

    #region ##### METHODS #####
    #endregion
}
