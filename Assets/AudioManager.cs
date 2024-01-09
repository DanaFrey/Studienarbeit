using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip mainscreen;
    public AudioClip click;
    public AudioClip world1level1;
    public AudioClip world2level1;
    public AudioClip world3level1;

    private void Start()
    {
        musicSource.clip = mainscreen;
        musicSource.Play();
    }
}
