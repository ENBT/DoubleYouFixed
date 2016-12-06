using UnityEngine;
using System.Collections;
using DG.Tweening;

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
            if (!isPaused)
            {
                DOTween.PauseAll();
            }

            if (isPaused)
            {
                DOTween.PlayAll();
                
            }
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
        if (isPaused)
            GameManager.Instance.state = game.pause;

        if (!isPaused)
            GameManager.Instance.state = game.game;
        //Change manager state here
    }

    public void Resume()
    {


        isPaused = false;
        DOTween.PlayAll();
        GameManager.Instance.state = game.game;
        UpdateDisplay();
        UpdateManagerState();
    }



}
