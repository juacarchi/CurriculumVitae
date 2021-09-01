﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //Declarar variable estática singleton
    public static SFXManager instance;
    AudioSource audioSource;
    public AudioClip jump;
    public AudioClip activeCube;
    public AudioClip changeScene;
    //Aqui podemos meter una serie de AudioClip para poder llamarlos desde otros elementos.
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //Método para reproducir un AudioClip que le pasemos al SoundManager.
    public void PlaySFX(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    //Método para modificar volumen
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
