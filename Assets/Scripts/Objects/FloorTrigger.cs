using UnityEngine;
using System.Collections;

public class FloorTrigger : InteractableObject
{


    InteractableObject floorTrigger;
    [SerializeField]
    GameObject trigger;
    AudioSource Sound;

    //Animator anim;



    void StartInteract()
    {
        if (floorTrigger.isActive)
            return;
        floorTrigger.isActive = true;
        Sound.Play();
        //anim.SetBool("Active", true);

    }


    public override void StopInteract()
    {
        if (!floorTrigger.isActive)
            return;
        floorTrigger.isActive = false;
        //anim.SetBool("Active", false);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<InteractableObject>().id == trigger.GetComponent<InteractableObject>().id)
            StartInteract();

    }

    void OnCollisionExit(Collision col)
    {

        if (col.gameObject.GetComponent<InteractableObject>().id == trigger.GetComponent<InteractableObject>().id)
            StopInteract();

    }



    // Use this for initialization
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        //anim = GetComponent<Animator>();
        floorTrigger = GetComponent<FloorTrigger>();
        floorTrigger.isActive = false;
        floorTrigger.type = Trigger;

    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
