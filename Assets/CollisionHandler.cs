using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long this is the only script to load scenes.

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFX;

    

    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");      
    }

    private void ReloadScene() //string referenced in OnTriggerEnter
    {
        SceneManager.LoadScene(1);
    }
}
