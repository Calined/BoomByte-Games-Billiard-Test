using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastGameScoreBoard : MonoBehaviour
{
    public Text shotsMadeText;
    public Text pointsText;
    public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();
    }

    void LoadGame()
    {

        if (PlayerPrefs.HasKey("SavedGame"))
        {
            SavedGame savedGame = new SavedGame();

            string jsonString = PlayerPrefs.GetString("SavedGame");

            savedGame = JsonUtility.FromJson<SavedGame>(jsonString);

            shotsMadeText.text = savedGame.shotsMade.ToString();
            pointsText.text = savedGame.playerPoints.ToString();

            timeText.text = Manager.manager.SecondsToTimeString(savedGame.secondsSpent);
        }

    }

}
