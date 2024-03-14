using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class World1Level1Logic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;
    public Text equationText;
    public Text answer1Text;
    public Text answer2Text;
    public Text answer3Text;
    public Text answer4Text;

    //[x][1] always represents the correct answer
    string[][] equations = new string[][]
    {
        new string[] {"6 x 50 = __ ?", "300", "240", "250", "360"},
        new string[] {"17 x 7 = __ ?", "119", "149", "122", "177"},
        new string[] {"35 : 5 = __ ?", "7", "5", "6", "8"},
        new string[] {"5 x 9 = __ ?", "45", "40", "36", "50"},
        new string[] {"469 – ( 154 – 84) = __ ?", "399", "400", "419", "379"},
        new string[] {"6 x (3 + 5) = __ ?", "48", "23", "33", "54"},
        new string[] {"(70 - 14) : 7 = __ ?", "8", "68", "49", "6"},
        new string[] {"650 - 64 = __ ?", "586", "596", "584", "594"},
    };
    //das oben sollte dasselbe sein wie:
    //equations[0][0] = "6 x 50 = __ ?";
    //equations[0][1] = "300";
    //equations[0][2] = "240";
    //equations[0][3] = "250";
    //equations[0][4] = "360";
    //equations[1][0] = "17 x 7 = __ ?";
    //equations[1][1] = "119";
    //equations[1][2] = "149";
    //equations[1][3] = "122";
    //equations[1][4] = "177";
    //...

    void Start()
    {
        volumeSettings.Start();
    }

    public void ReturnToWorld1Menu()
    {
        SceneManager.LoadScene("World 1");
    }

    public void LoadNextEquation()
    {
        //this takes a random equation of the array equations and also randomizes the order of answers
        int[] answersIndices = { 1, 2, 3, 4 };
        System.Random r = new System.Random();
        int rInt = r.Next(0, equations.Length);
        equationText.text = equations[rInt][0];
        int randomAnswersIndices = r.Next(0, answersIndices.Length);
        answer1Text.text = equations[rInt][answersIndices[randomAnswersIndices]];
        answersIndices = answersIndices.Where((value, index) => index != randomAnswersIndices).ToArray();
        randomAnswersIndices = r.Next(0, answersIndices.Length);
        answer2Text.text = equations[rInt][answersIndices[randomAnswersIndices]];
        answersIndices = answersIndices.Where((value, index) => index != randomAnswersIndices).ToArray();
        randomAnswersIndices = r.Next(0, answersIndices.Length);
        answer3Text.text = equations[rInt][answersIndices[randomAnswersIndices]];
        answersIndices = answersIndices.Where((value, index) => index != randomAnswersIndices).ToArray();
        randomAnswersIndices = r.Next(0, answersIndices.Length);
        answer4Text.text = equations[rInt][answersIndices[randomAnswersIndices]];
        answersIndices = answersIndices.Where((value, index) => index != randomAnswersIndices).ToArray();
        equations = equations.Where((value, index) => index != rInt).ToArray();
    }
}
