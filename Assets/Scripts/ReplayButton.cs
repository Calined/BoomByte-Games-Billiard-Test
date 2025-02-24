﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Button>().interactable = Manager.manager.ballsAreMoving || Input.GetButton("Jump") || Manager.manager.shotsMade == 0 ? false : true;
    }

    public void ReplayLastMove()
    {
        Manager.manager.replayIsOn = true;

        Manager.manager.ReplayLoad();
    }
}
