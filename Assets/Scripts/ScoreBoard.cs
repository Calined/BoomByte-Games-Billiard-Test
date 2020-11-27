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

        timeText.text = Manager.manager.SecondsToTimeString(Manager.manager.secondsSpent);

        if (Manager.manager.playerPoints >= 3)
        {
            Manager.manager.gameIsRunning = false;
            winScreen.SetActive(true);

            SaveGame();
        }
    }


    void SaveGame()
    {
        SavedGame savedGame = new SavedGame();

        savedGame.shotsMade = Manager.manager.shotsMade;
        savedGame.playerPoints = Manager.manager.playerPoints;
        savedGame.secondsSpent = Manager.manager.secondsSpent;

        string jsonString = JsonUtility.ToJson(savedGame);

        PlayerPrefs.SetString("SavedGame", jsonString);

    }

}
