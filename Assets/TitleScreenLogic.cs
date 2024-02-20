using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenLogic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;

    public InputField username;
    public InputField password;
    public GameObject settingsScreen;
    public GameObject loginScreen;
    public GameObject loggedInScreen;
    public GameObject messageBox;

    public void Start()
    {
        volumeSettings.Start();
    }
    public void openSettings()
    {
        username.text = "";
        password.text = "";
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
        username.text = "";
        password.text = "";
        messageBox.SetActive(false);
        if (settingsScreen.activeSelf) settingsScreen.SetActive(false);
        if (DBManager.LoggedIn)
        {
            if (loggedInScreen.activeSelf) loggedInScreen.SetActive(false);
            else loggedInScreen.SetActive(true);
        }
        else
        {
            if (loginScreen.activeSelf) loginScreen.SetActive(false);
            else loginScreen.SetActive(true);
        }
    }

    public void closeLogin()
    {
        username.text = "";
        password.text = "";
        loginScreen.SetActive(false);
        loggedInScreen.SetActive(false);
        messageBox.SetActive(false);
    }
}