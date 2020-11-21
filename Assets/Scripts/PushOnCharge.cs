using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushOnCharge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonUp("Jump"))
        {
            PushBall();
        }
    }


    void PushBall()
    {
        Debug.Log("Push");
    }


}
