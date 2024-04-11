using System;
using System.Collections;
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
    public Text score;
    public Text grade;
    public Text time;
    public Text endScore;
    public Text endTime;
    private int endTimeInSeconds;
    public GameObject resultScreen;
    public GameObject settingsScreen;
    public GameObject messageBox;
    private string rightAnswer = "";
    private float currentTime;
    private bool timerActive = false;
    private int equationsCount = 0;

    //[x][1] always represents the correct answer
    string[][] equations = new string[][]
    {
        //45 equastions
        new string[] {"6 x 50 = __ ?", "300", "240", "250", "360"},
        new string[] {"17 x 7 = __ ?", "119", "149", "122", "177"},
        new string[] {"35 : 5 = __ ?", "7", "5", "6", "8"},
        new string[] {"5 x 9 = __ ?", "45", "40", "36", "50"},
        new string[] {"469 – ( 154 – 84) = __ ?", "399", "400", "419", "379"},
        new string[] {"6 x (3 + 5) = __ ?", "48", "23", "33", "54"},
        new string[] {"(70 - 14) : 7 = __ ?", "8", "68", "49", "6"},
        new string[] {"650 - 64 = __ ?", "586", "596", "584", "594"},
        new string[] {"8 x 20 = __ ?", "160", "140", "180", "200"},
        new string[] {"13 x 6 = __ ?", "78", "68", "88", "72"},
        new string[] {"42 : 7 = __ ?", "6", "8", "5", "7"},
        new string[] {"9 x 8 = __ ?", "72", "64", "81", "56"},
        new string[] {"537 – ( 256 – 126) = __ ?", "407", "417", "427", "397"},
        new string[] {"7 x (4 + 6) = __ ?", "70", "34", "63", "64"},
        new string[] {"(90 - 18) : 6 = __ ?", "12", "87", "64", "8"},
        new string[] {"820 - 76 = __ ?", "744", "764", "784", "734"},
        new string[] {"24 x 4 = __ ?", "96", "86", "104", "88"},
        new string[] {"56 : 8 = __ ?", "7", "6", "8", "9"},
        new string[] {"7 x 11 = __ ?", "77", "66", "88", "70"},
        new string[] {"629 – ( 375 – 175) = __ ?", "429", "439", "449", "419"},
        new string[] {"9 x (6 + 7) = __ ?", "117", "76", "61", "81"},
        new string[] {"(120 - 24) : 6 = __ ?", "16", "96", "116", "12"},
        new string[] {"950 - 84 = __ ?", "866", "876", "886", "856"},
        new string[] {"3.5 x 4 = __ ?", "14", "13", "15", "12"},
        new string[] {"7.2 x 2 = __ ?", "14.4", "12.2", "15.2", "13.4"},
        new string[] {"15.6 : 3 = __ ?", "5.2", "4.6", "6.2", "5.6"},
        new string[] {"2.3 x 6 = __ ?", "13.8", "14.3", "12.3", "13.2"},
        new string[] {"12.7 – ( 6.4 – 2.1) = __ ?", "8.4", "9.1", "7.4", "8.9"},
        new string[] {"4.5 x (2 + 3) = __ ?", "22.5", "18.5", "20.5", "24.5"},
        new string[] {"(18.9 - 4.1) : 2 = __ ?", "7.4", "8.6", "6.4", "7.8"},
        new string[] {"36.4 - 6.6 = __ ?", "29.8", "28.4", "30.4", "29.6"},
        new string[] {"5.2 x 3 = __ ?", "15.6", "14.2", "16.2", "13.8"},
        new string[] {"8.7 x 2 = __ ?", "17.4", "18.7", "16.4", "15.7"},
        new string[] {"14.4 : 2 = __ ?", "7.2", "6.4", "8.4", "7.8"},
        new string[] {"3.6 x 5 = __ ?", "18", "16", "19", "17"},
        new string[] {"6.8 x (3 + 2) = __ ?", "34", "30", "28", "32"},
        new string[] {"(19.8 - 3.4) : 2 = __ ?", "8.2", "8.6", "7.6", "8.3"},
        new string[] {"42.6 - 8.3 = __ ?", "34.3", "33.6", "35.6", "34.8"},
        new string[] {"4.3 x 2 = __ ?", "8.6", "7.6", "9.6", "8.3"},
        new string[] {"9.6 : 3 = __ ?", "3.2", "3.6", "6.9", "2.6"},
        new string[] {"18.9 : 3 = __ ?", "6.3", "5.9", "7.3", "6.9"},
        new string[] {"7.4 x 4 = __ ?", "29.6", "28.4", "30.4", "27.6"},
        new string[] {"36.7 – (14.2 – 8.2) = __ ?", "30.7", "31.8", "32.1", "30.5"},
        new string[] {"5.5 x (4 + 3) = __ ?", "38.5", "33.5", "40.5", "35.5"},
        new string[] {"(25.6 - 5.8) : 2 = __ ?", "9.9", "9.4", "10.1", "9.1"},
        new string[] {"48.9 - 9.2 = __ ?", "39.7", "38.1", "40.1", "39.5"},
    };

    void Start()
    {
        volumeSettings.Start();
        currentTime = 0;
        StartTimer();
        LoadNextEquation();
    }

    void Update()
    {
        if (timerActive)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
        time.text = timeSpan.Minutes.ToString() + ":" + timeSpan.Seconds.ToString();
        endTimeInSeconds = (int)currentTime;
    }

    public void ReturnToWorld1Menu()
    {
        SceneManager.LoadScene("World 1");
    }

    public void LoadNextEquation()
    {
        try
        {
            if(equationsCount == 10)
            {
                throw new IndexOutOfRangeException();
            }
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
            equationsCount++;
        }catch(IndexOutOfRangeException ex)
        {
            StopTimer();
            resultScreen.SetActive(true);
            grade.text = DetermineGrade(int.Parse(score.text), endTimeInSeconds);
            endTime.text = time.text;
            endScore.text = score.text;
            StartCoroutine(SaveScore());
        }
    }

    IEnumerator SaveScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 1);
        form.AddField("level", 1);
        form.AddField("grade", grade.text);
        WWW www = new WWW("http://localhost/sqlconnect/writescore.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("Successfully written score into database.");
        }
        else
        {
            Debug.Log("Error while writing score into database.");

        }
    }

    public void DetermineButton1Right()
    {
        if (answer1Text.text == rightAnswer)
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt++;
            score.text = scoreInt.ToString();
        }
        LoadNextEquation();
    }

    public void DetermineButton2Right()
    {
        if (answer2Text.text == rightAnswer)
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt++;
            score.text = scoreInt.ToString();
        }
        LoadNextEquation();
    }

    public void DetermineButton3Right()
    {
        if (answer3Text.text == rightAnswer)
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt++;
            score.text = scoreInt.ToString();
        }
        LoadNextEquation();
    }

    public void DetermineButton4Right()
    {
        if (answer4Text.text == rightAnswer)
        {
            int scoreInt = Int32.Parse(score.text);
            scoreInt++;
            score.text = scoreInt.ToString();
        }
        LoadNextEquation();
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    public string DetermineGrade(int score, int time)
    {
        string gradeString = "";
        float result = (float) score / (float) time;
        Debug.Log("Result: " + result);
        if (0 <= result  && result <= 0.02){
            gradeString = "F";
        }else if(0.02 <= result && result < 0.03)
        {
            gradeString = "E";
        }else if (0.03 <= result && result < 0.04)
        {
            gradeString = "D";
        }else if (0.04 <= result && result < 0.071)
        {
            gradeString = "C";
        }else if (0.071 <= result && result < 0.0925)
        {
            if (score < 6)
            {
                gradeString = "E";
            }
            else
            {
                gradeString = "B";
            }
        }
        else if (0.0925 <= result)
        {
            if(score < 8)
            {
                gradeString = "E";
            }
            else
            {
                gradeString = "A";
            }
        }
        return gradeString;
    }

    public void ResumeButton()
    {
        SceneManager.LoadScene("World 1");
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
