using UnityEngine;
using System.Collections;
using System;

public class Box : InteractableObject
{
    [SerializeField]
    bool held;

    [SerializeField]
    float distance;

    Player activator;
    Rigidbody body;


    Vector3 veloc = Vector3.zero;

    InteractableObject box;







   


    public override void StartInteract(Player p)
    {
        if (held)
            return;

        activator = p;
        isActive = true;

        Pickup();

    }


    
    public override void StopInteract()
    {
        if (!held)
            return;
        activator = null;
        isActive = false;
        Drop();
    }

    




    void Awake()
    {
        body = GetComponent<Rigidbody>();
        box = GetComponent<Box>();
        box.type = Hold;
    }
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (held)
            Carry();

    }


    void Pickup()
    {
        held = true;
        body.useGravity = false;
        body.freezeRotation = true;
        
        body.position = Vector3.SmoothDamp(body.position, activator.head.transform.position + activator.head.transform.forward * distance,
            ref veloc, Time.deltaTime * .05f);


    }

    void Drop()
    {
        held = false;
        body.useGravity = true;
        body.freezeRotation = false;
    }

    void Carry()
    {
        if (!held)
            return;
        Vector3 fwz = activator.head.transform.position + activator.head.transform.forward * distance;

        body.position = Vector3.SmoothDamp(body.position, fwz,
            ref veloc, Time.deltaTime * 3.5f, 4.8f);
        

        

    }

}
