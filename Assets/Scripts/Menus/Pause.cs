using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool isPaused;
    public GameObject PauseMenu;
    public Timer level_timer;

	// Use this for initialization
	void Start ()
    {
        
        isPaused = false;
        PauseMenu = GameObject.Find("PauseMenu");
        level_timer = GameObject.Find("Timer").GetComponent<Timer>();
        UpdateDisplay();
        UpdateManagerState();
        
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            UpdateManagerState();
            UpdateDisplay();
        }
	}

    private void UpdateDisplay()
    {
        PauseMenu.SetActive(isPaused);
        level_timer.isPaused = isPaused;
    }

    private void UpdateManagerState()
    {
        //Change manager state here
    }

    public void Resume()
    {
        isPaused = false;
        UpdateDisplay();
        UpdateManagerState();
    }



}
