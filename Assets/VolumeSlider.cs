using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SliderValueChanged(GetComponent<Slider>().value);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SliderValueChanged(System.Single volume)
    {

        Manager.manager.currentVolume = volume;

    }

}
