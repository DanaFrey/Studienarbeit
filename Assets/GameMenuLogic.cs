using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuLogic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;
    public Button world1;
    public Button world2;
    public Button world3;
    public GameObject messageBox;
    public Text messageText;

    void Start()
    {
        volumeSettings.Start();
    }

    private void Update()
    {
        if (DBManager.LoggedIn)
        {
            world1.interactable = true;
            world2.interactable = true;
            world3.interactable = true;
        }
        else
        {
            AllButtonsLocked();
            messageBox.SetActive(true);
            messageText.text = "You have to log in or register to play.";
        }
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }

    public void LoadWorld1()
    {
        SceneManager.LoadScene("World 1");
    }
    public void LoadWorld2()
    {
        SceneManager.LoadScene("World 2");
    }
    public void LoadWorld3()
    {
        SceneManager.LoadScene("World 3");
    }

    public void AllButtonsLocked()
    {
        world1.interactable = false;
        world2.interactable = false;
        world3.interactable = false;
    }
}
