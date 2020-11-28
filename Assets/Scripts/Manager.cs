using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager manager;
    public ScoreBoard scoreBoard;

    public float currentVolume = 1f;

    public int shotsMade = 0;
    public int playerPoints = 0;
    public int secondsSpent = 0;


    public bool redBallHit = false;
    public bool yellowBallHit = false;

    public bool gameIsRunning = true;
    public bool ballsAreMoving = false;
    public bool replayIsOn = false;

    public List<GameObject> balls;

    void Awake()
    {
        if (!manager)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            manager.secondsSpent = 0;
            Destroy(gameObject);
        }

    }



    // Start is called before the first frame update
    void Start()
    {

    }

    void StartGame()
    {
        shotsMade = 0;
        playerPoints = 0;
        secondsSpent = 0;

        gameIsRunning = true;
        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        while (gameIsRunning)
        {
            yield return new WaitForSeconds(1);
            if (!replayIsOn && gameIsRunning)
            {
                secondsSpent++;
                scoreBoard.UpdateBoard();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForSleepingBalls();
    }

    void CheckForSleepingBalls()
    {
        bool allSleeping = true;
        foreach (GameObject ball in balls)
        {
            if (!ball.GetComponent<Rigidbody>().IsSleeping())
            {

                allSleeping = false;
            }
        }

        if (allSleeping)
        {
            ballsAreMoving = false;

            if (redBallHit && yellowBallHit && !replayIsOn)
            {
                playerPoints++;
                scoreBoard.UpdateBoard();
            }

            redBallHit = false;
            yellowBallHit = false;

            replayIsOn = false;

        }
        else
        {
            ballsAreMoving = true;
        }

    }

    public void LoadBilliardScene()
    {
        balls.Clear();
        SceneManager.LoadScene("billiard");
        StartGame();
    }

    public void LoadMainMenu()
    {
        balls.Clear();
        SceneManager.LoadScene("menu");
    }


    public string SecondsToTimeString(int secondsInput)
    {
        int seconds = secondsInput % 60;
        int minutes = (secondsInput - seconds) / 60;

        string minutesString = minutes > 9 ? minutes.ToString() : "0" + minutes.ToString();
        string secondsString = seconds > 9 ? seconds.ToString() : "0" + seconds.ToString();

        return minutesString + ":" + secondsString;
    }

    public void ReplaySave()
    {
        foreach (GameObject ball in balls)
        {
            ball.GetComponent<BallCollision>().ReplaySave();
        }
    }

    public void ReplayLoad()
    {
        GameObject whiteBall = null;

        foreach (GameObject ball in balls)
        {
            if (ball.name == "WhiteBall")
            {
                whiteBall = ball;
            }

            ball.GetComponent<BallCollision>().ReplayLoad();
        }

        whiteBall.GetComponent<PushOnCharge>().ReplayLoad();

    }

}
