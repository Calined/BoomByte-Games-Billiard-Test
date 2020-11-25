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
        currentBallCharge += 0.4f * Time.deltaTime;
    }

    void PushBall()
    {
        Debug.Log("Push " + currentBallCharge);

        Vector3 pushVector = Camera.main.transform.forward;

        pushVector = Vector3.Scale(pushVector, new Vector3(1f, 0f, 1f));

        GetComponent<Rigidbody>().AddForce(pushVector * currentBallCharge * 1000);

        currentBallCharge = 0f;
    }



}
