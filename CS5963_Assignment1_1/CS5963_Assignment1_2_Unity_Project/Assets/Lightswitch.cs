using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : MonoBehaviour
{

    List<Color> coloArray = new List<Color>{ Color.blue, Color.red, Color.green, Color.cyan, Color.yellow };

    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }
    
    int i = 0;
    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("tab"))
        {
            light.color = coloArray[i];
            i++;
            if (i > coloArray.Count-1)
                i = 0;
        }
    }
}
