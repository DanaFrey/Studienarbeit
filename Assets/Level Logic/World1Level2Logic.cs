using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class World1Level2Logic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;
    public Text score;
    public Text grade;
    public Text time;
    public Text endScore;
    public Text endTime;
    public Text exerciseText;
    private int endTimeInSeconds;
    public GameObject resultScreen;
    public GameObject settingsScreen;
    public GameObject messageBox;
    public GameObject correctHandHours;
    public GameObject correctHandMinutes;
    public GameObject handHours;
    public GameObject handMinutes;
    public Button hoursUp;
    public Button hoursDown;
    public Button minutesUp;
    public Button minutesDown;
    private float currentTime;
    private bool timerActive = false;
    private int exerciseCount = 0;
    private int currEx = 0;
    private float tolerance = 5f;
    private bool withinToleranceHours = false;
    private bool withinToleranceMinutes = false;
    private bool gameRunning = false;

    //task, correct rotation of hour hand, correct rotation of minutes hand
    //12 = 0 rotation, 1 = -30, 2 = -60, 3 = -90, ...
    string[][] exercises = new string[][]
    {
        //55 exercises
        new string[] {"12:25", "-15", "-150"},
        new string[] {"1:40", "-48", "120"},
        new string[] {"13:40", "-48", "120"},
        new string[] {"13:25", "-45", "-150"},
        new string[] {"2:10", "-63", "-60"},
        new string[] {"14:10", "-63", "-60"},
        new string[] {"2:55", "-84", "30"},
        new string[] {"14:55", "-84", "30"},
        new string[] {"3:30", "-105", "-180"},
        new string[] {"15:30", "-105", "-180"},
        new string[] {"3:05", "-90", "-30"},
        new string[] {"15:05", "-90", "-30"},
        new string[] {"4:20", "-130", "-120"},
        new string[] {"16:20", "-130", "-120"},
        new string[] {"4:35", "-135", "150"},
        new string[] {"16:35", "-135", "150"},
        new string[] {"5:45", "-170", "90"},
        new string[] {"17:45", "-170", "90"},
        new string[] {"5:40", "-168", "120"},
        new string[] {"17:40", "-168", "120"},
        new string[] {"6:00", "-180", "0"},
        new string[] {"18:00", "-180", "0"},
        new string[] {"7:45", "130", "90"},
        new string[] {"19:45", "130", "90"},
        new string[] {"7:20", "138", "-120"},
        new string[] {"19:20", "138", "-120"},
        new string[] {"8:10", "118", "-60"},
        new string[] {"20:10", "118", "-60"},
        new string[] {"8:05", "120", "-30"},
        new string[] {"20:05", "120", "-30"},
        new string[] {"9:35", "75", "150"},
        new string[] {"21:35", "75", "150"},
        new string[] {"9:00", "90", "0"},
        new string[] {"21:00", "90", "0"},
        new string[] {"9:50", "65", "60"},
        new string[] {"21:50", "65", "60"},
        new string[] {"10:00", "60", "0"},
        new string[] {"22:00", "60", "0"},
        new string[] {"10:30", "45", "-180"},
        new string[] {"22:30", "45", "-180"},
        new string[] {"11:20", "17", "-120"},
        new string[] {"23:20", "17", "-120"},
        new string[] {"11:50", "5", "60"},
        new string[] {"23:50", "5", "60"},
        new string[] {"12:40", "-18", "120"},
        new string[] {"00:40", "-18", "120"},
        new string[] {"00:15", "-6", "-90"},
        new string[] {"14:04", "-60", "-23"},
        new string[] {"05:47", "-170", "77"},
        new string[] {"17:28", "-165", "-167"},
        new string[] {"02:11", "-66", "-65"},
        new string[] {"15:29", "-105", "-173"},
        new string[] {"18:53", "160", "40"},
        new string[] {"08:22", "111", "-132"},
        new string[] {"10:33", "45", "160"},
        new string[] {"00:19", "-6", "-115"},
    };

    void Start()
    {
        gameRunning = true;
        volumeSettings.Start();
        currentTime = 0;
        StartTimer();
        LoadNextExercise();
    }
    void Update()
    {
        if (gameRunning == true)
        {
            withinToleranceHours = Quaternion.Angle(handHours.transform.rotation, Quaternion.Euler(new Vector3(0, 0, float.Parse(exercises[currEx][1])))) <= tolerance;
            withinToleranceMinutes = Quaternion.Angle(handMinutes.transform.rotation, Quaternion.Euler(new Vector3(0, 0, float.Parse(exercises[currEx][2])))) <= tolerance;
            if (withinToleranceHours && withinToleranceMinutes)
            {
                int scoreInt = Int32.Parse(score.text);
                scoreInt++;
                score.text = scoreInt.ToString();
                handHours.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                handMinutes.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                //remove the exercise from the exercises array
                exercises = exercises.Where((value, index) => index != currEx).ToArray();
                exerciseCount++;
                LoadNextExercise();
            }
            if (timerActive)
            {
                currentTime = currentTime + Time.deltaTime;
            }
            TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
            time.text = timeSpan.Minutes.ToString() + ":" + timeSpan.Seconds.ToString();
            endTimeInSeconds = (int)currentTime;
        }
    }

    public void ReturnToWorld1Menu()
    {
        SceneManager.LoadScene("World 1");
    }

    public void LoadNextExercise()
    {
        try
        {
            //MAYBE NOCH ANDERE ANZAHL ALS 10 NEHMEN
            if (exerciseCount == 10 && exercises.Length == 0 || exerciseCount == 10)
            {
                throw new IndexOutOfRangeException();
            }
            //pick a random exercise
            System.Random r = new System.Random();
            currEx = r.Next(0, exercises.Length);
            exerciseText.text = exercises[currEx][0];
            //change rotation of correct hands
            float corrRotHours = float.Parse(exercises[currEx][1]);
            float corrRotMinutes = float.Parse(exercises[currEx][2]);
            correctHandHours.transform.rotation = Quaternion.Euler(new Vector3(0, 0, corrRotHours));
            correctHandMinutes.transform.rotation = Quaternion.Euler(new Vector3(0, 0, corrRotMinutes));
        }
        catch (IndexOutOfRangeException ex)
        {
            gameRunning = false;
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
        form.AddField("level", 2);
        form.AddField("grade", grade.text);
        WWW www = new WWW("http://localhost/sqlconnect/writescore.php", form);
        yield return www;

        if (www.text == "0")
        {
            Debug.Log("Successfully written score into database.");
        }
        else
        {
            Debug.Log("Error while writing score into database: " + www.text);

        }
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
        float result = (float)score / (float)time;
        if (0 <= result && result <= 0.02)
        {
            gradeString = "F";
        }
        else if (0.02 <= result && result < 0.03)
        {
            gradeString = "E";
        }
        else if (0.03 <= result && result < 0.04)
        {
            gradeString = "D";
        }
        else if (0.04 <= result && result < 0.071)
        {
            gradeString = "C";
        }
        else if (0.071 <= result && result < 0.0925)
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
            if (score < 8)
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
