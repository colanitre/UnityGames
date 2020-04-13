using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float levelLoadDelay = 5f;

    void Start()
    {
        Invoke("LoadFirstScene", levelLoadDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
