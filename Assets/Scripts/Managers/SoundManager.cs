using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    #region ############### VARIABLES ###############
    public AudioMixer audioMixer;
    #endregion
    #region ############### EVENTS ###############

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }

    #endregion


    #region ################ METHODS ################
    /// <summary>
    /// configura el volumen del canal master
    /// </summary>
    /// <param name="volume"></param>
    public void SetMasterVolume(float volume) {
        audioMixer.SetFloat("MasterVolume", volume);
    }


    /// <summary>
    /// configura el volumen del canal de sonido
    /// </summary>
    /// <param name="volume"></param>
    public void SetSoundVolume(float volume) {
        audioMixer.SetFloat("EFXVolume", volume);
    }

    /// <summary>
    /// configura el volumen del canal de musica
    /// </summary>
    /// <param name="volume"></param>
    public void SetMusicVolume(float volume) {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    #endregion
}
