using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private float level_time;
    private Text textDisplay;
    public bool isPaused;


    // Use this for initialization
    void Start ()
    {
        isPaused = false;
        level_time = 0;
        textDisplay = this.gameObject.GetComponentInChildren<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!isPaused)
        {
            level_time += Time.deltaTime;
        }

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        textDisplay.text = String.Format("Time: {0:#,###.00} sec", level_time);

    }



}
