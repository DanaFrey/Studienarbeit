using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class World2Level1Logic : MonoBehaviour
{
    [SerializeField] private VolumeSettings volumeSettings;
    public Text score;
    public Text grade;
    public Text time;
    public Text endScore;
    public Text endTime;
    private int endTimeInSeconds;
    public GameObject resultScreen;
    public GameObject settingsScreen;
    public GameObject messageBox;
    public GameObject barGoal;
    public GameObject bigBarPrefab;
    public GameObject capsulePrefab;
    public GameObject circlePrefab;
    public GameObject horizontalBarBigPrefab;
    public GameObject horizontalBarMediumPrefab;
    public GameObject horizontalBarSmallPrefab;
    public GameObject mediumBarPrefab;
    public GameObject rectanglePrefab;
    public GameObject roofPrefab;
    public GameObject smallBarPrefab;
    public GameObject squarePrefab;
    public GameObject trianglePrefab;
    public GameObject horizontalRectanglePrefab;
    private List<GameObject> spawnedBlocks;
    private float currentTime;
    private bool timerActive = false;
    private int taskCount = 0;

    //strings represent which blocks can be used for this task, [x][0] always reprensents the height of the bar (257 - 557 are 4 good heights)
    //usable blocks are: Roof, Rectangle, Square, Triangle, Circle, Capsule, SmallBar, MediumBar, BigBar, HorizontalSmallBar, HorizontalMediumBar,
    //                   HorizontalBigBar, HorizontalRectangle
    string[][] tasks = new string[][]
    {
        //x tasks
        new string[] {"257", "Roof", "Square", "Triangle", "Capsule", "Square", "MediumBar"},
        new string[] {"257", "Roof", "Square", "Triangle", "Capsule", "Square", "MediumBar"},
        new string[] {"257", "Roof", "Square", "Triangle", "Capsule", "Square", "MediumBar"},
        new string[] {"257", "Roof", "Square", "Triangle", "Capsule", "Square", "MediumBar"},
        new string[] {"257", "Roof", "Square", "Triangle", "Capsule", "Square", "MediumBar"},
        new string[] {"257", "Roof", "Square", "Triangle", "Capsule", "Square", "MediumBar"},
        new string[] {"257", "Roof", "Square", "Triangle", "Capsule", "Square", "MediumBar"},
    };

    void Start()
    {
        spawnedBlocks = new List<GameObject>();
        volumeSettings.Start();
        currentTime = 0;
        StartTimer();
        LoadNextTask();
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

    public void ReturnToWorld2Menu()
    {
        SceneManager.LoadScene("World 2");
    }

    public void LoadNextTask()
    {
        try
        {
            if (taskCount == 10)
            {
                throw new IndexOutOfRangeException();
            }
            //pick a random task
            System.Random r = new System.Random();
            int rInt = r.Next(0, tasks.Length);
            //set the bar the player should reach to the height given in the array
            int height = Int32.Parse(tasks[rInt][0]);
            barGoal.transform.position = new Vector3((float) 566.5, height, (float) -0.1);
            //spawn the given blocks
            for (int i = 1; i < tasks[rInt].Length; i++)
            {
                //usable blocks are: Roof, Rectangle, Square, Triangle, Circle, Capsule, SmallBar, MediumBar, BigBar, HorizontalSmallBar, HorizontalMediumBar,
                //                   HorizontalBigBar, HorizontalRectangle
                Debug.Log("Iteration i = " + i);
                if (tasks[rInt][i] == "Roof")
                {
                    Debug.Log("roof");
                    GameObject block = Instantiate(roofPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    Debug.Log("roof2");
                    spawnedBlocks.Add(block);
                    Debug.Log("roof3");
                }
                else if (tasks[rInt][i] == "Square")
                {
                    Debug.Log("square");
                    GameObject block = Instantiate(squarePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "Rectangle")
                {
                    GameObject block = Instantiate(rectanglePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "Triangle")
                {
                    GameObject block = Instantiate(trianglePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "Circle")
                {
                    GameObject block = Instantiate(circlePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "Capsule")
                {
                    GameObject block = Instantiate(capsulePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "SmallBar")
                {
                    GameObject block = Instantiate(smallBarPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "MediumBar")
                {
                    GameObject block = Instantiate(mediumBarPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "BigBar")
                {
                    GameObject block = Instantiate(bigBarPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "HorizontalSmallBar")
                {
                    GameObject block = Instantiate(horizontalBarSmallPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "HorizontalMediumBar")
                {
                    GameObject block = Instantiate(horizontalBarMediumPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "HorizontalBigBar")
                {
                    GameObject block = Instantiate(horizontalBarBigPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }
                else if (tasks[rInt][i] == "HorizontalRectangle")
                {
                    GameObject block = Instantiate(horizontalRectanglePrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    spawnedBlocks.Add(block);
                }

                if (i == 1)
                {
                    Debug.Log("spawne ganz rechts");
                    spawnedBlocks[i - 1].transform.position = new Vector3(1030, 200, -1);
                }
                else if(i == 2)
                {
                    Debug.Log("spawne fast ganz rechts");
                    spawnedBlocks[i - 1].transform.position = new Vector3(930, 120, -1);
                }
                else if (i == 3)
                {
                    spawnedBlocks[i - 1].transform.position = new Vector3(830, 200, -1);
                }
                else if (i == 4)
                {
                    spawnedBlocks[i - 1].transform.position = new Vector3(110, 200, -1);
                }
                else if (i == 5)
                {
                    spawnedBlocks[i - 1].transform.position = new Vector3(210, 120, -1);
                }
                else if (i == 6)
                {
                    spawnedBlocks[i - 1].transform.position = new Vector3(310, 200, -1);
                }
            }
            //remove the task from the tasks array
            tasks = tasks.Where((value, index) => index != rInt).ToArray();
            taskCount++;
        }
        catch (IndexOutOfRangeException ex)
        {
            StopTimer();
            resultScreen.SetActive(true);
            grade.text = DetermineGrade(endTimeInSeconds);
            endTime.text = time.text;
            endScore.text = score.text;
            StartCoroutine(SaveScore());
        }
    }

    IEnumerator SaveScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("world", 2);
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

    public string DetermineGrade(int time)
    {
        string gradeString = "";
        if ((0 <= time && time <= 35) || time >= 160)
        {
            gradeString = "F";
        }
        else if (140 <= time && time < 160)
        {
            gradeString = "E";
        }
        else if (120 <= time && time < 140)
        {
            gradeString = "D";
        }
        else if (100 <= time && time < 120)
        {
            gradeString = "C";
        }
        else if (75 <= time && time < 100)
        {
            gradeString = "B";
        }
        else if (35 < time && time < 75)
        {
            gradeString = "A";
        }

        return gradeString;
    }

    public void ResumeButton()
    {
        SceneManager.LoadScene("World 2");
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