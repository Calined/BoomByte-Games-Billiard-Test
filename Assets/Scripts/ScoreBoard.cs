using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text shotsMadeText;
    public Text pointsText;
    public Text timeText;
    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        Manager.manager.scoreBoard = this;
    }

    public void UpdateBoard()
    {
        shotsMadeText.text = Manager.manager.shotsMade.ToString();
        pointsText.text = Manager.manager.playerPoints.ToString();

        int seconds = Manager.manager.secondsSpent % 60;
        int minutes = (Manager.manager.secondsSpent - seconds) / 60;

        timeText.text = minutes + ":" + seconds;

        if (Manager.manager.playerPoints >= 3)
        {
            Manager.manager.gameIsRunning = false;
            winScreen.SetActive(true);
        }
    }
}
