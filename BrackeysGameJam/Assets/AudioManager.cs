using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    static bool created = false;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
        music = GetComponent<AudioSource>();
        Debug.Log(music.clip.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Music", 1) != 1)
        {
            music.Pause();
        }
        else
        {
            if (music.isPlaying != true)
            {
                music.Play();
            }
        }
    }

}
