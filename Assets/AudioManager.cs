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

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        musicSource.clip = mainscreen;
        musicSource.Play();
    }

    private void Update()
    {
        ChangeMusic();
    }

    private void ChangeMusic()
    {
        if (SceneManager.GetActiveScene().name == "World 1 Level 1" && musicSource.clip != world1level1)
        {
            musicSource.Stop();
            musicSource.clip = world1level1;
            musicSource.Play();
        }else if(SceneManager.GetActiveScene().name == "World 2 Level 1" && musicSource.clip != world2level1)
        {
            musicSource.Stop();
            musicSource.clip = world2level1;
            musicSource.Play();
        }else if (SceneManager.GetActiveScene().name == "World 3 Level 1" && musicSource.clip != world3level1)
        {
            musicSource.Stop();
            musicSource.clip = world3level1;
            musicSource.Play();
        }
    }
}
