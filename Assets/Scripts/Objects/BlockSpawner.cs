using UnityEngine;
using System.Collections;

public class BlockSpawner : InteractableObject {


    InteractableObject spawner;
    [SerializeField]
    InteractableObject trigger;

    [SerializeField]
    GameObject spawned;

    [SerializeField]
    bool blockactive;

	// Use this for initialization
	void Start () {

        spawner = GetComponent<BlockSpawner>();
        spawner.isActive = false;
        blockactive = false;
        spawner.type = Switch;
	
	}


    void StartInteract()
    {
        if (spawner.isActive)
            return;

        Debug.Log("My Bababooey");
        spawner.isActive = true;
        Spawn();
    }


    void Spawn()
    {

        if (blockactive)
            return;


        spawned.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Instantiate(spawned, transform.position, Quaternion.identity);
        blockactive = true;
        
        trigger.StopInteract();

        
    }
	
	// Update is called once per frame
	void Update () {
        if (trigger.isActive)
            StartInteract();
	
	}
}
