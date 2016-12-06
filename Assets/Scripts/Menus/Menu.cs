using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {



	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}


    public void StartLevel()
    {
        SceneManager.LoadScene("Level1");
        //Change game manager state here
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //Change game manager state here
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        //Change game manager state here
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Change game manager state here
    }


}
