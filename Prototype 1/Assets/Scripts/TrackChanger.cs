using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChanger : MonoBehaviour
{

    public AudioSource _audioSource;
    public AudioSource _audioSource2;
    private GameObject[] other;
    private bool NotFirst = false;
    

    private void Awake()
    {
        other = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject oneOther in other)
        {
            if (oneOther.scene.buildIndex == -1)
            {
                NotFirst = true;
            }
        }

        if (NotFirst == true)
        {
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(transform.gameObject);
        //_audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 1.0f;
        _audioSource2.volume = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        PlayMusic();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
        _audioSource2.Play();
        _audioSource.volume = 1.0f;
        _audioSource2.volume = 0f;
    }

    public void ChangeMusic()
    {
        if(_audioSource.volume > _audioSource2.volume)
        {
            _audioSource.volume = 0.0f;
            _audioSource2.volume = 1.0f;
            // _audioSource.mute = true;
            // _audioSource2.mute = false;
        }
        else
        {
            _audioSource.volume = 1.0f;
            _audioSource2.volume = 0.0f;
            // _audioSource.mute = false;
            // _audioSource2.mute = true;
        }

    }


}
