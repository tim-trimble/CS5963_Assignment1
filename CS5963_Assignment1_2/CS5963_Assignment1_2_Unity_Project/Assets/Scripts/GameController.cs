using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScorePointEvent : UnityEvent<int>{}

public class GameController : MonoBehaviour {

    public static GameController instance;

    public ScorePointEvent ScorePoint;

    int Score;
    List<LightController> lights;
    LightController activeLight;
    bool hasStarted = false;
	// Use this for initialization
	void Awake () {
		if(instance != null)
        {
            Destroy(this);
        }
        
        instance = this;
        if (ScorePoint == null)
        {
            ScorePoint = new ScorePointEvent();
        }
        Score = 0;
        lights = new List<LightController>();
    }

    public void ConnectLight(LightController l)
    {
        lights.Add(l);
        l.LightSelectedEvent.AddListener(PointScored);
        ChangeActiveLight();
    }

    public void PointScored()
    {
        CancelInvoke();
        hasStarted = false;
        Score++;
        ScorePoint.Invoke(Score);

        Debug.Log(Score);
    }

    void ChangeActiveLight()
    {
        int randint = Random.Range(0, lights.Count);
        if (activeLight != null)
        {
            activeLight.SetLightStatus(false);
        }
        activeLight = lights[randint];
        activeLight.SetLightStatus(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButton("Exit"))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        if (!hasStarted)
        {
            hasStarted = true;
            InvokeRepeating("ChangeActiveLight", 0f, 3f);
        }
	}
}
