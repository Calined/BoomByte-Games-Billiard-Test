using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        Manager.manager.balls.Add(this.gameObject);

        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<Rigidbody>().velocity.magnitude < 0.3f && GetComponent<Rigidbody>().velocity.magnitude > 0.01f)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
        myAudioSource.volume = Manager.manager.currentVolume * GetComponent<Rigidbody>().velocity.magnitude / 10f;
        myAudioSource.Play();

        if (gameObject.name == "WhiteBall")
        {
            if (collision.gameObject.name == "YellowBall")
            {
                Manager.manager.yellowBallHit = true;

            }

            if (collision.gameObject.name == "RedBall")
            {
                Manager.manager.redBallHit = true;

            }


        }
    }



}
