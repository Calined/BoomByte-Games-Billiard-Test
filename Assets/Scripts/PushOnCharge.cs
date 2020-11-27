using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOnCharge : MonoBehaviour
{
    private float currentBallCharge = 0f;

    public Transform targetRay;
    public Transform reflectionRay;

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

        pushVector = Camera.main.transform.forward;

        pushVector = Vector3.Scale(pushVector, new Vector3(1f, 0f, 1f));

        currentBallCharge += 0.4f * Time.deltaTime;

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

            float reflectionRayLength = rayLenght - targetRayLength;

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
        targetRay.gameObject.SetActive(false);
        reflectionRay.gameObject.SetActive(false);

        GetComponent<Rigidbody>().AddForce(pushVector * currentBallCharge * 1000);

        Manager.manager.shotsMade++;
        Manager.manager.scoreBoard.UpdateBoard();

        currentBallCharge = 0f;
    }



}
