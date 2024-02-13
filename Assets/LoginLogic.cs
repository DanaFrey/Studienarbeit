using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//used for UnityWebRequest
//using UnityEngine.Networking;

public class LoginLogic : MonoBehaviour
{
    public bool loggedIn = false;
    public InputField username;
    public InputField password;
    public Button registerButton;
    public GameObject loginScreenSignedOut;
    public GameObject loginScreenSignedIn;
    public GameObject messageBox;
    public Text messageText;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        //eventually, change from WWWForm to newer UnityWebRequest
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("User created successfully.");
            messageBox.SetActive(false);
            //loginScreenSignedOut.SetActive(false);
            //loginScreenSignedIn.SetActive(true);
        }
        else
        {
            messageBox.SetActive(true);
            messageText.text = "User registration failed. Error #" + www.text;

        }
    }

    public void VerifyInputs()
    {
        //The username should be between 5 and 16 characters long and the password should be at least 6 characters long
        registerButton.interactable = (username.text.Length >= 5 && username.text.Length <= 16 && password.text.Length >= 6);
    }
}
