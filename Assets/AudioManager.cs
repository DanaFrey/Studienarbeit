using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip mainscreen;
    public AudioClip gamemenu;
    public AudioClip click;
    public AudioClip world1level1;
    public AudioClip world2level1;
    public AudioClip world3level1;
    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "Title Screen")
        {
            musicSource.clip = mainscreen;
        }else if(SceneManager.GetActiveScene().name == "Game Menu")
        {
            //mainscreen.Stop();
            musicSource.clip = gamemenu;
        }
        musicSource.Play();
    }
}
