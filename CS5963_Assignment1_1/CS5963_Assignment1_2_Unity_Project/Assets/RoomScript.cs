using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{

    public GameObject room2Floor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            //Inconsistent coding for room relocation but idc
            this.gameObject.transform.position = new Vector3(0, 1, 0);
        }

        if (Input.GetKeyDown("2"))
        {
            this.gameObject.transform.position = new Vector3(room2Floor.transform.position.x, room2Floor.transform.position.y + 1, room2Floor.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }
    }
}
