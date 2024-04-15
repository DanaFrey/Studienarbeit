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
    public GameObject scoreWorld1;
    public Text world1Grade;
    public GameObject scoreWorld2;
    public Text world2Grade;
    public GameObject scoreWorld3;
    public Text world3Grade;
    public GameObject scoreWorld4;
    public Text world4Grade;
    public GameObject scoreWorld5;
    public Text world5Grade;
    public GameObject scoreWorld6;
    public Text world6Grade;

    void Start()
    {
        volumeSettings.Start();
        if(DBManager.LoggedIn)
        {
            StartCoroutine(GetAvgScoreWorld1());
            StartCoroutine(GetAvgScoreWorld2());
            StartCoroutine(GetAvgScoreWorld3());
            StartCoroutine(GetAvgScoreWorld4());
            StartCoroutine(GetAvgScoreWorld5());
            StartCoroutine(GetAvgScoreWorld6());
        }
    }

    IEnumerator GetAvgScoreWorld1()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 1);
        form.AddField("levelcount", 6);
        WWW www = new WWW("http://localhost/sqlconnect/getavgscore.php", form);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            if (www.text == "0")
            {

            }
            else
            {
                scoreWorld1.SetActive(true);
                world1Grade.text = www.text;
            }
        }
        else
        {
            Debug.LogError("Error while retrieving score data: " + www.error);
        }
    }

    IEnumerator GetAvgScoreWorld2()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 2);
        form.AddField("levelcount", 6);
        WWW www = new WWW("http://localhost/sqlconnect/getavgscore.php", form);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            if (www.text == "0")
            {

            }
            else
            {
                scoreWorld2.SetActive(true);
                world2Grade.text = www.text;
            }
        }
        else
        {
            Debug.LogError("Error while retrieving score data: " + www.error);
        }
    }

    IEnumerator GetAvgScoreWorld3()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 3);
        form.AddField("levelcount", 6);
        WWW www = new WWW("http://localhost/sqlconnect/getavgscore.php", form);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            if (www.text == "0")
            {

            }
            else
            {
                scoreWorld3.SetActive(true);
                world3Grade.text = www.text;
            }
        }
        else
        {
            Debug.LogError("Error while retrieving score data: " + www.error);
        }
    }

    IEnumerator GetAvgScoreWorld4()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 4);
        form.AddField("levelcount", 6);
        WWW www = new WWW("http://localhost/sqlconnect/getavgscore.php", form);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            if (www.text == "0")
            {

            }
            else
            {
                scoreWorld4.SetActive(true);
                world4Grade.text = www.text;
            }
        }
        else
        {
            Debug.LogError("Error while retrieving score data: " + www.error);
        }
    }

    IEnumerator GetAvgScoreWorld5()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 5);
        form.AddField("levelcount", 6);
        WWW www = new WWW("http://localhost/sqlconnect/getavgscore.php", form);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            if (www.text == "0")
            {

            }
            else
            {
                scoreWorld5.SetActive(true);
                world5Grade.text = www.text;
            }
        }
        else
        {
            Debug.LogError("Error while retrieving score data: " + www.error);
        }
    }

    IEnumerator GetAvgScoreWorld6()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 6);
        form.AddField("levelcount", 6);
        WWW www = new WWW("http://localhost/sqlconnect/getavgscore.php", form);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            if (www.text == "0")
            {

            }
            else
            {
                scoreWorld6.SetActive(true);
                world6Grade.text = www.text;
            }
        }
        else
        {
            Debug.LogError("Error while retrieving score data: " + www.error);
        }
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
