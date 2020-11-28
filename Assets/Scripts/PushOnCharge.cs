using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOnCharge : MonoBehaviour
{
    float currentBallCharge = 0f;

    public Transform targetRay;
    public Transform reflectionRay;

    Vector3 pushVector;

    float previousPushCarge;
    Vector3 previousPushVector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.manager.gameIsRunning && !Manager.manager.ballsAreMoving)
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
    }


    void ChargeBall()
    {

        pushVector = Camera.main.transform.forward;

        pushVector = Vector3.Scale(pushVector, new Vector3(1f, 0f, 1f));

        currentBallCharge += 0.4f * Time.deltaTime;

        currentBallCharge = Mathf.Min(1f, currentBallCharge);

        DrawTargetRay();

    }

    void DrawTargetRay()
    {
        targetRay.gameObject.SetActive(true);

        targetRay.LookAt(transform.position + pushVector);

        float rayLenght = currentBallCharge * 27f;
        float targetRayLength;

        RaycastHit hit;



        if (Physics.Raycast(transform.position, pushVector, out hit, rayLenght))
        {
            reflectionRay.gameObject.SetActive(true);
            reflectionRay.transform.position = hit.point;
            reflectionRay.transform.LookAt(reflectionRay.transform.position + Vector3.Reflect(pushVector, hit.normal));

            targetRayLength = Vector3.Distance(transform.position, hit.point);

            float reflectionRayLength = (rayLenght - targetRayLength) * 0.6f;

            reflectionRay.localScale = new Vector3(2f, 2f, reflectionRayLength);
        }
        else
        {
            reflectionRay.gameObject.SetActive(false);

            targetRayLength = rayLenght;
        }

        targetRay.localScale = new Vector3(2f, 2f, targetRayLength);

    }

    void PushBall()
    {

        ReplaySave();

        targetRay.gameObject.SetActive(false);
        reflectionRay.gameObject.SetActive(false);

        GetComponent<Rigidbody>().AddForce(pushVector * currentBallCharge * 1000);

        if (!Manager.manager.replayIsOn)
        {
            Manager.manager.shotsMade++;
            Manager.manager.scoreBoard.UpdateBoard();
        }

        currentBallCharge = 0f;
    }

    void ReplaySave()
    {
        previousPushCarge = currentBallCharge;
        previousPushVector = pushVector;

        Manager.manager.ReplaySave();
    }

    public void ReplayLoad()
    {
        currentBallCharge = previousPushCarge;
        pushVector = previousPushVector;

        PushBall();
    }

}
