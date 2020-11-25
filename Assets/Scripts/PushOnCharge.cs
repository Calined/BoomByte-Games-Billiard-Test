using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOnCharge : MonoBehaviour
{
    private float currentBallCharge = 0f;

    public Transform targetRay;

    private Vector3 pushVector;


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
        targetRay.gameObject.SetActive(true);

        pushVector = Camera.main.transform.forward;

        pushVector = Vector3.Scale(pushVector, new Vector3(1f, 0f, 1f));

        targetRay.LookAt(transform.position + pushVector);


        currentBallCharge += 0.4f * Time.deltaTime;

    }

    void PushBall()
    {
        targetRay.gameObject.SetActive(false);

        GetComponent<Rigidbody>().AddForce(pushVector * currentBallCharge * 1000);

        currentBallCharge = 0f;
    }



}
