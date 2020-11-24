using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOnCharge : MonoBehaviour
{
    private float currentBallCharge = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Jump"))
        {
            ChargeBall();
        }

        if (Input.GetButtonUp("Jump"))
        {
            PushBall();
        }
    }


    void ChargeBall()
    {
        currentBallCharge += 0.5f * Time.deltaTime;
    }

    void PushBall()
    {
        Debug.Log("Push " + currentBallCharge);

        currentBallCharge = 0f;
    }


}
