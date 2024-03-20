using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class World1Logic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;
    public Button level1;
    public GameObject settingsScreen;
    public GameObject messageBox;
    public Text messageText;

    void Start()
    {
        volumeSettings.Start();
        //HIER SOLL ABGEFRAGT WERDEN, OB ES IN DER DATENBANK FÜR LEVEL X EINEN HINTERLEGTEN SCORE GIBT, FALLS JA -> ANZEIGEN DER NOTE
    }

    public void ReturnToGameMenu()
    {
        SceneManager.LoadScene("Game Menu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("World1Level1");
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
