using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenLogic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;

    public GameObject settingsScreen;
    public GameObject loginScreen;

    public void Start()
    {
        volumeSettings.Start();
    }
    public void openSettings()
    {
        settingsScreen.SetActive(true);
    }

    public void closeSettings()
    {
        settingsScreen.SetActive(false);
    }

    public void openLogin()
    {
        loginScreen.SetActive(true);
    }

    public void closeLogin()
    {
        loginScreen.SetActive(false);
    }
}