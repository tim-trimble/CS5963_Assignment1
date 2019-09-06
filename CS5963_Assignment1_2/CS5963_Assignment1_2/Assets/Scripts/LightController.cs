using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Light))]
public class LightController : MonoBehaviour
{
    public UnityEvent LightSelectedEvent;
    public Color ActiveColor;
    public Color ReachColor;

    Light light;
    bool isActiveLight = false;

    // Use this for initialization
    void Start()
    {
        LightSelectedEvent = new UnityEvent();
        light = GetComponent<Light>();
        light.enabled = false;

        GameController.instance.ConnectLight(this);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && isActiveLight)
        {
            light.color = ReachColor;
            if (Input.GetButton("Fire1"))
            {
                LightSelectedEvent.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player" && isActiveLight)
        {
            light.color = ActiveColor;
        }
    }

    public void SetLightStatus(bool status)
    {
        light.color = ActiveColor;
        isActiveLight = status;
        light.enabled = status;
    }
}



