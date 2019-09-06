using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        GameController.instance.ScorePoint.AddListener(UpdateScore);
        UpdateScore(0);
	}
	
    public void UpdateScore(int score)
    {
        scoreText.text = "YOUR SCORE IS: " + score.ToString();
    }
}
