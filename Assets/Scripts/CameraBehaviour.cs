using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform positionTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.manager.gameIsRunning && !Manager.manager.ballsAreMoving)
        {
            transform.position = positionTarget.position;

            transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * Time.deltaTime * 50f);
        }
    }
}
