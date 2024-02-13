using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenLogic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;

    public GameObject settingsScreen;
    public GameObject loginScreen;
    public GameObject messageBox;

    public void Start()
    {
        volumeSettings.Start();
    }
    public void openSettings()
    {
        messageBox.SetActive(false);
        if (loginScreen.activeSelf) loginScreen.SetActive(false);
        if (settingsScreen.activeSelf) settingsScreen.SetActive(false);
        else settingsScreen.SetActive(true);
    }

    public void closeSettings()
    {
        messageBox.SetActive(false);
        settingsScreen.SetActive(false);
    }

    public void openLogin()
    {
        messageBox.SetActive(false);
        if (settingsScreen.activeSelf) settingsScreen.SetActive(false);
        if (loginScreen.activeSelf) loginScreen.SetActive(false);
        else loginScreen.SetActive(true);
    }

    public void closeLogin()
    {
        loginScreen.SetActive(false);
        messageBox.SetActive(false);
    }
}