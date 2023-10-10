using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenLogic : MonoBehaviour
{
    public GameObject settingsScreen;

    public void openSettings(){
        settingsScreen.SetActive(true);
    }

    public void closeSettings(){
        settingsScreen.SetActive(false);
    }
}
