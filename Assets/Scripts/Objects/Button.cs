using UnityEngine;
using System.Collections;
using System;

public class Button : InteractableObject {

    InteractableObject button;
    AudioSource Sound;
    Animator anim;
    Player activator;

    [SerializeField]
    bool isTimed;

    [SerializeField]
    float Timer;

    float currTime = 0.0f;



    public override void StartInteract(Player p)
    {
        if (button.isActive)
            return;

        Debug.Log("Bababooey");
        button.isActive = true;
        Press();
    }

    public override void StopInteract()
    {

        if (!button.isActive)
            return;
        button.isActive = false;
        
    }

    void Press()
    {
        Debug.Log("hiya");
        anim.SetBool("Pressed", true);
        Sound.Play();

        
        
    }

    // Use this for initialization
    void Start () {
        Sound = GetComponent<AudioSource>();
        button = GetComponent<Button>();
        button.isActive = false;
        button.type = Activate;
        anim = GetComponent<Animator>();
        anim.SetBool("Pressed", false);

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
