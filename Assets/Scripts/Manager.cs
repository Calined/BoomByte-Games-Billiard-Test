using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager manager;

    public float currentVolume = 1f;
    public int playerPoints = 0;
    public bool redBallHit = false;
    public bool yellowBallHit = false;

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
            Destroy(gameObject);
        }

    }



    // Start is called before the first frame update
    void Start()
    {

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
            redBallHit = false;
            yellowBallHit = false;
        }

    }

    public void LoadBilliardScene()
    {

        SceneManager.LoadScene("billiard");
    }

}
