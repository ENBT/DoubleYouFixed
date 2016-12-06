using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TeleporterTrigger : MonoBehaviour {

    [SerializeField]
    private string NextScene;

    Teleporter[] TeleporterList;



    // Use this for initialization
    void Start ()
    {
        TeleporterList= this.gameObject.GetComponentsInChildren<Teleporter>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(TeleporterList[0].Triggered() && TeleporterList[1].Triggered())
        {
            SceneManager.LoadScene(NextScene);
        }
	}




}
