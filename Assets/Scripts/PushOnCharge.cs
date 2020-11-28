using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOnCharge : MonoBehaviour
{
    float currentBallCharge = 0f;

    public List<Transform> targetRays;

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

        DrawAllTargetRays();

    }

    void DrawAllTargetRays()
    {
        float totalRayLenghtLeft = currentBallCharge * 27f;
        float currentTargetRayLength = 0f;

        Vector3 currentDirection = pushVector;

        Vector3 previousHit = transform.position;

        foreach (Transform targetRay in targetRays)
        {
            if (totalRayLenghtLeft > 0)
            {
                targetRay.position = previousHit;

                targetRay.LookAt(targetRay.position + currentDirection);

                RaycastHit hit;

                if (Physics.Raycast(targetRay.position, currentDirection, out hit, totalRayLenghtLeft))
                {
                    currentTargetRayLength = Vector3.Distance(targetRay.position, hit.point);

                    currentDirection = Vector3.Reflect(currentDirection, hit.normal);

                    previousHit = hit.point;
                }
                else
                {
                    currentTargetRayLength = totalRayLenghtLeft;
                }

                targetRay.localScale = new Vector3(2f, 2f, currentTargetRayLength);

                targetRay.gameObject.SetActive(true);

                totalRayLenghtLeft -= currentTargetRayLength;

            }

            else
            {
                targetRay.gameObject.SetActive(false);
            }

        }
    }


    void PushBall()
    {

        ReplaySave();

        foreach (Transform targetRay in targetRays)
        {
            targetRay.gameObject.SetActive(false);
        }

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
