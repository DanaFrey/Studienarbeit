using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System.Diagnostics;

public class World1Level1Logic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;
    public Text equationText;
    public Text answer1Text;
    public Text answer2Text;
    public Text answer3Text;
    public Text answer4Text;
    public Text score;
    public Text grade;
    public Text time;
    public Text endScore;
    public GameObject resultScreen;
    public string rightAnswer = "";

    Stopwatch stopwatch = new Stopwatch();

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

    void Start()
    {
        volumeSettings.Start();
        LoadNextEquation();
        stopwatch.Start();
    }

    void Update()
    {
        //HIER EVTL IMPLEMENTIEREN, DASS DER TIMER DAUERHAFT AKTUALISIERT WIRD
    }

    public void ReturnToWorld1Menu()
    {
        SceneManager.LoadScene("World 1");
    }

    public void LoadNextEquation()
    {
        try
        {
            //the four answer buttons
            int[] answersIndices = { 1, 2, 3, 4 };
            //pick a random equation
            System.Random r = new System.Random();
            int rInt = r.Next(0, equations.Length);
            equationText.text = equations[rInt][0];
            //equations[x][1] always represent the right answer
            rightAnswer = equations[rInt][1];
            //randomize the order of answers
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
            //remove the equation from the equations array
            equations = equations.Where((value, index) => index != rInt).ToArray();
        }catch(IndexOutOfRangeException ex)
        {
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            string elapsedTimeString = elapsedTime.ToString();
            resultScreen.SetActive(true);
            grade.text = DetermineGrade();
            time.text = elapsedTimeString;
            endScore.text = score.text;
            //RESULTS SCRENN MUSS NOCH GEMACHT WERDEN, SOLL NOTE, SCORE, GEBRAUCHTE ZEIT, RESUME BUTTON BEINHALTEN
        }
    }

    public void DetermineButton1Right()
    {
        if (answer1Text.text == rightAnswer)
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt++;
            score.text = scoreInt.ToString();
            LoadNextEquation();
        }
        else
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt--;
            score.text = scoreInt.ToString();
        }
    }

    public void DetermineButton2Right()
    {
        if (answer2Text.text == rightAnswer)
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt++;
            score.text = scoreInt.ToString();
            LoadNextEquation();
        }
        else
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt--;
            score.text = scoreInt.ToString();
        }
    }

    public void DetermineButton3Right()
    {
        if (answer3Text.text == rightAnswer)
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt++;
            score.text = scoreInt.ToString();
            LoadNextEquation();
        }
        else
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt--;
            score.text = scoreInt.ToString();
        }
    }

    public void DetermineButton4Right()
    {
        if (answer4Text.text == rightAnswer)
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt++;
            score.text = scoreInt.ToString();
            LoadNextEquation();
        }
        else
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt--;
            score.text = scoreInt.ToString();
        }
    }

    public string DetermineGrade()
    {
        string gradeString = "";
        //MUSS NOCH IMPLEMENTIERT WERDEN
        //evtl score durch Zeit vom Timer, dann je nachdem in welcher Range dieses ergebnis is, zuteilung auf grades a bis f
        return gradeString;
    }
}
