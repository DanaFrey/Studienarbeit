using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class World3Logic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;
    public Button level1;
    public GameObject settingsScreen;
    public GameObject messageBox;
    public Text messageText;

    void Start()
    {
        volumeSettings.Start();
    }

    public void ReturnToGameMenu()
    {
        SceneManager.LoadScene("Game Menu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("World3Level1");
    }

    public void openSettings()
    {
        if (settingsScreen.activeSelf) settingsScreen.SetActive(false);
        else settingsScreen.SetActive(true);
    }

    public void closeSettings()
    {
        messageBox.SetActive(false);
        settingsScreen.SetActive(false);
    }
}
