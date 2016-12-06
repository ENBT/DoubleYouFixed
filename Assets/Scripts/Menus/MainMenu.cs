using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    GameObject MenuDisplay;
    GameObject ControlDisplay;


	// Use this for initialization
	void Start ()
    {
        MenuDisplay = GameObject.Find("MainMenu");
        ControlDisplay = GameObject.Find("Controls");

        ControlDisplay.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {

	}


    public void Controls()
    {
        MenuDisplay.SetActive(false);
        ControlDisplay.SetActive(true);
    }

    public void Back()
    {
        MenuDisplay.SetActive(true);
        ControlDisplay.SetActive(false);
    }


}
