using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text shotsMadeText;

    // Start is called before the first frame update
    void Start()
    {
        Manager.manager.scoreBoard = this;
    }

    public void UpdateBoard()
    {
        shotsMadeText.text = Manager.manager.shotsMade.ToString();
    }
}
