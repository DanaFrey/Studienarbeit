using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class World2Logic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;
    public Button level1;
    public GameObject settingsScreen;
    public GameObject messageBox;
    public Text messageText;
    public GameObject scoreLvl1;
    public Text level1Grade;

    void Start()
    {
        volumeSettings.Start();
        StartCoroutine(GetScoreLevel1());
    }

    public void ReturnToGameMenu()
    {
        SceneManager.LoadScene("Game Menu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("World2Level1");
    }

    IEnumerator GetScoreLevel1()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 2);
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
