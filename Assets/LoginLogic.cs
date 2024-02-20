using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoginLogic : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public Button registerButton;
    public Button loginButton;
    public Button showPassButton;
    public Button hidePassButton;
    public GameObject loginScreenSignedOut;
    public GameObject loginScreenSignedIn;
    public GameObject messageBox;
    public Text messageText;
    public Text displayName;

    private void Start()
    {
        password.contentType = InputField.ContentType.Password;
    }

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    public void CallLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Register()
    {
        //eventually, change from WWWForm to newer UnityWebRequest, possible approach:
        //WWWForm form = new WWWForm();
        //form.AddField("username", username.text);
        //form.AddField("password", password.text);
        //using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form))
        //{
            //yield return www.SendWebRequest();
            //if (www.result == UnityWebRequest.Result.ConnectionError)
            //{
                //messageBox.SetActive(true);
                //messageText.text = "User registration failed. Error #" + www.result;
            //}
            //else
            //{
                //Debug.Log("User created successfully.");
                //messageBox.SetActive(false);
                //loginScreenSignedOut.SetActive(false);
                //loginScreenSignedIn.SetActive(true);
            //}
        //}

        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;

        if (www.text == "0")
        {
            string message = "Registration was successful";
            StartCoroutine(LateCall(messageBox, messageText, message));
            DBManager.username = username.text;
            displayName.text = username.text;
            loginScreenSignedOut.SetActive(false);
            loginScreenSignedIn.SetActive(true);
            username.text = "";
            password.text = "";
            Debug.Log("User created successfully.");
        }
        else
        {
            messageBox.SetActive(true);
            messageText.text = "User registration failed. Error #" + www.text;

        }
    }

    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;

        if (www.text.Equals("0"))
        {
            string message = "Login was successful";
            StartCoroutine(LateCall(messageBox, messageText, message));
            DBManager.username = username.text;
            displayName.text = username.text;
            loginScreenSignedOut.SetActive(false);
            loginScreenSignedIn.SetActive(true);
            username.text = "";
            password.text = "";
            Debug.Log("Logged in successfully.");
        }
        else
        {
            messageBox.SetActive(true);
            messageText.text = "Login failed. Error #" + www.text;
        }
    }

    public void LogOut()
    {
        DBManager.username = null;
        loginScreenSignedIn.SetActive(false);
        loginScreenSignedOut.SetActive(true);
    }

    IEnumerator LateCall(GameObject gameObj, Text messageText, string message)
    {
        gameObj.SetActive(true);
        messageText.text = message;
        yield return new WaitForSeconds(3);
        gameObj.SetActive(false);
    }

    public void VerifyInputs()
    {
        //The username should be between 5 and 13 characters long and the password should be at least 6 characters long
        registerButton.interactable = (username.text.Length >= 5 && username.text.Length <= 13 && password.text.Length >= 6);
        loginButton.interactable = (username.text.Length >= 5 && username.text.Length <= 13 && password.text.Length >= 6);
    }

    public void showPass()
    {
        showPassButton.gameObject.SetActive(false);
        password.contentType = InputField.ContentType.Standard;
        password.DeactivateInputField();
        password.ActivateInputField();
        hidePassButton.gameObject.SetActive(true);
    }

    public void hidePass()
    {
        hidePassButton.gameObject.SetActive(false);
        password.contentType = InputField.ContentType.Password;
        password.DeactivateInputField();
        password.ActivateInputField();
        showPassButton.gameObject.SetActive(true);
    }


}
