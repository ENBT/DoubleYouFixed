using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    private bool IsTriggered;
    [SerializeField]
    private string player;

	// Use this for initialization
	void Start ()
    {
        IsTriggered = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == player)
        {
            IsTriggered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == player)
        {
            IsTriggered = false;
        }
    }


    public bool Triggered()
    {
        return IsTriggered;
    }






}
