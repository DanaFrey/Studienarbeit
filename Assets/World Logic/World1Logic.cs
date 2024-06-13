using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class World1Logic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;
    public Button level1;
    public GameObject settingsScreen;
    public GameObject messageBox;
    public GameObject scoreLvl1;
    public Text level1Grade;
    public GameObject scoreLvl2;
    public Text level2Grade;
    public GameObject scoreLvl3;
    public Text level3Grade;
    public GameObject scoreLvl4;
    public Text level4Grade;
    public GameObject scoreLvl5;
    public Text level5Grade;
    public GameObject scoreLvl6;
    public Text level6Grade;
    public Text messageText;

    void Start()
    {
        volumeSettings.Start();
        StartCoroutine(GetScoreLevel1());
        StartCoroutine(GetScoreLevel2());
    }

    IEnumerator GetScoreLevel1()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 1);
        form.AddField("level", 1);
        WWW www = new WWW("http://localhost/sqlconnect/getscore.php", form);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            if (www.text == "0")
            {
               
            }
            else
            {
                scoreLvl1.SetActive(true);
                level1Grade.text = www.text;
            }
        }
        else
        {
            Debug.LogError("Error while retrieving score data: " + www.error);
        }
    }

    IEnumerator GetScoreLevel2()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 1);
        form.AddField("level", 2);
        WWW www = new WWW("http://localhost/sqlconnect/getscore.php", form);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            if (www.text == "0")
            {

            }
            else
            {
                scoreLvl2.SetActive(true);
                level2Grade.text = www.text;
            }
        }
        else
        {
            Debug.LogError("Error while retrieving score data: " + www.error);
        }
    }

    public void ReturnToGameMenu()
    {
        SceneManager.LoadScene("Game Menu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("World1Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("World1Level2");
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
