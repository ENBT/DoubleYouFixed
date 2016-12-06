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

    public void Quit()
    {
        Application.Quit();
    }

    public void StartLevel()
    {
        GameManager.Instance.state = game.game;
        SceneManager.LoadScene("Level1");
        
        //Change game manager state here
    }

    public void MainMenu()
    {
        GameManager.Instance.state = game.mainmenu;
        SceneManager.LoadScene("MainMenu");
        //Change game manager state here
    }

    public void Credits()
    {

        GameManager.Instance.state = game.credits;
        SceneManager.LoadScene("Credits");
        //Change game manager state here
    }

    public void RestartLevel()
    {

        GameManager.Instance.state = game.game;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Change game manager state here
    }


}
