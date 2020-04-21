using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 5f;
    // Start is called before the first frame update
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
