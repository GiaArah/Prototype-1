using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioSource _audioSource2;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Exit game
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        // Restart game
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //_audioSource.Play();
            //_audioSource2.Play();
        }
    }
}
