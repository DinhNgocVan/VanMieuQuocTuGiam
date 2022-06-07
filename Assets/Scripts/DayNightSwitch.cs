using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSwitch : MonoBehaviour
{
    public Material skyMode;
    public Material nightMode;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skyMode;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            RenderSettings.skybox = nightMode;
        } else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RenderSettings.skybox = skyMode;
        }
    }
}
