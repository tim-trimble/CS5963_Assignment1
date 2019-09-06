using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float movementSpeed;


    private void Start()
    {
        if(movementSpeed == 0)
        {
            movementSpeed = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float translationForward = Input.GetAxis("Vertical") * movementSpeed;
        float translationSideways = Input.GetAxis("Horizontal") * movementSpeed;
        translationForward *= Time.deltaTime;
        translationSideways *= Time.deltaTime;
        transform.Translate(translationSideways, 0, translationForward);
    }
}
