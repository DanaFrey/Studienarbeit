using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenLogic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;

    public InputField username;
    public InputField password;
    public InputField currentPassword;
    public InputField newPassword;
    public GameObject settingsScreen;
    public GameObject loginScreen;
    public GameObject loggedInScreen;
    public GameObject messageBox;
    public Button showPassButton;
    public Button hidePassButton;
    public Button showCurrentPassButton;
    public Button hideCurrentPassButton;
    public Button showNewPassButton;
    public Button hideNewPassButton;
    public Text displayName;

    public void Start()
    {
        volumeSettings.Start();
    }
    public void openSettings()
    {
        generalReset();
        if (loginScreen.activeSelf) loginScreen.SetActive(false);
        if (loggedInScreen.activeSelf) loggedInScreen.SetActive(false);
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
        generalReset();
        if (settingsScreen.activeSelf) settingsScreen.SetActive(false);
        if (DBManager.LoggedIn)
        {
            displayName.text = DBManager.username;
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
        generalReset();
        loginScreen.SetActive(false);
        loggedInScreen.SetActive(false);
        messageBox.SetActive(false);
    }

    public void generalReset()
    {
        username.text = "";
        password.text = "";
        currentPassword.text = "";
        newPassword.text = "";
        messageBox.SetActive(false);
        hideCurrentPass();
        hideNewPass();
        hidePassLogin();
    }

    public void hideCurrentPass()
    {
        hideCurrentPassButton.gameObject.SetActive(false);
        currentPassword.contentType = InputField.ContentType.Password;
        currentPassword.DeactivateInputField();
        currentPassword.ActivateInputField();
        showCurrentPassButton.gameObject.SetActive(true);
    }

    public void hideNewPass()
    {
        hideNewPassButton.gameObject.SetActive(false);
        newPassword.contentType = InputField.ContentType.Password;
        newPassword.DeactivateInputField();
        newPassword.ActivateInputField();
        showNewPassButton.gameObject.SetActive(true);
    }

    public void hidePassLogin()
    {
        hidePassButton.gameObject.SetActive(false);
        password.contentType = InputField.ContentType.Password;
        password.DeactivateInputField();
        password.ActivateInputField();
        showPassButton.gameObject.SetActive(true);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game Menu");
    }
}