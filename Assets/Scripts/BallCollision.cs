using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        myAudioSource.volume = Manager.manager.currentVolume;
        myAudioSource.Play();

        if (gameObject.name == "WhiteBall")
        {
            if (collision.gameObject.name == "YellowBall")
            {
                Manager.manager.yellowBallHit = true;

                if (Manager.manager.redBallHit)
                {
                    Manager.manager.playerPoints++;
                }
            }

            if (collision.gameObject.name == "RedBall")
            {
                Manager.manager.redBallHit = true;

                if (Manager.manager.yellowBallHit)
                {
                    Manager.manager.playerPoints++;
                }
            }


        }
    }

}
