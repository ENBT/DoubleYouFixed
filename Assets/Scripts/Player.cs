using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public enum playerstate
{
    init,
    active,
    inactive
}
public class Player : MonoBehaviour
{


    public GameObject head;
    [SerializeField]
    float maxrot;

    Vector3 dir = Vector3.zero;
    Vector3 rot = Vector3.zero;

    const float grav = 9.8f;

    RaycastHit obj;

    [SerializeField]
    float movespeed;

    [SerializeField]
    float rotspeed;

    public bool canmove;

    CharacterController charcont;

    public playerstate currentstate;
    List<KeyValuePair<playerstate, playerstate>> states = new List<KeyValuePair<playerstate, playerstate>>();

    bool interactable;
    [SerializeField]
    bool interacting;
    [SerializeField]
    InteractableObject interactobj;




    void Awake()
    {
        canmove = true;
        states.Add(new KeyValuePair<playerstate, playerstate>(playerstate.init, playerstate.active));
        states.Add(new KeyValuePair<playerstate, playerstate>(playerstate.init, playerstate.inactive));
        states.Add(new KeyValuePair<playerstate, playerstate>(playerstate.active, playerstate.inactive));
        states.Add(new KeyValuePair<playerstate, playerstate>(playerstate.inactive, playerstate.active));
        charcont = GetComponent<CharacterController>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        switch (GameManager.Instance.state)
        {

            case game.game:
                switch (currentstate)
                {
                    case playerstate.active:
                        Controls();
                        break;

                    case playerstate.inactive:
                        break;

                    case playerstate.init:
                        StartCoroutine(SetMeUp());
                        break;
                }
                break;
        }
        

    }

    IEnumerator SetMeUp()
    {
        while (!charcont.isGrounded)
        {
            yield return null;
            dir.y -= grav * Time.deltaTime;
            charcont.Move(dir * Time.deltaTime);

        }

        Transition(playerstate.inactive);
        yield break;
    }



    void CheckInteractions()
    {

        interactable = Physics.SphereCast(head.transform.position, .3f, head.transform.TransformDirection(new Vector3(0, 0, .001f)), out obj, 1f, 1 << LayerMask.NameToLayer("Interactables"));

        if (!interactable)
            interactobj = null;


        if (obj.transform != null)
        {
            interactobj = obj.transform.GetComponent<InteractableObject>();
        }
        if (interactobj != null && interactobj.isActive)
        {
            if (interactobj.type == InteractableObject.Hold && Vector3.Distance(head.transform.position, interactobj.transform.position) > 3.5f)
            {
                interactobj.StopInteract();
                interacting = false;
                interactobj = null;
            }

            if (Inputs.B_Button())
            {
                interactobj.StopInteract();
                interacting = false;

            }
        }
        else if (!interacting && interactobj != null && Inputs.B_Button())
        {
            switch (interactobj.type)
            {
                case 1:
                    interactobj.StartInteract(GetComponent<Player>());
                    interacting = true;
                    break;
                case 2:
                    break;
                case 3:
                    interactobj.StartInteract(GetComponent<Player>());
                    break;

                case 4:
                    break;
                default:
                    Debug.Log("Unknown Object Type");
                    break;
            }

        }


    }
    void Controls()
    {




        if (canmove)
        {

            CheckInteractions();




            dir.x = Inputs.HorizontalAxis();
            dir.z = Inputs.VerticalAxis();
            rot.y = Inputs.CamHorizontalAxis();
            rot.x = Inputs.CamVerticalAxis();


            dir.x *= movespeed;
            dir.z *= movespeed;
            if (charcont.isGrounded)
            {
                dir = new Vector3(Inputs.HorizontalAxis(), 0, Inputs.VerticalAxis());
                dir = transform.TransformDirection(dir);
                dir *= movespeed;



            }

            head.transform.eulerAngles = new Vector3(head.transform.eulerAngles.x + rot.x, head.transform.eulerAngles.y, head.transform.eulerAngles.z);
            if (head.transform.eulerAngles.x > 30f && head.transform.eulerAngles.x < -60f && rot.x > 0)
            {
                head.transform.eulerAngles = new Vector3(30f, head.transform.eulerAngles.y, head.transform.eulerAngles.z);
            }
            if (head.transform.eulerAngles.x < -60f && rot.x < 0)
            {
                head.transform.eulerAngles = new Vector3(-60f, head.transform.eulerAngles.y, head.transform.eulerAngles.z);
            }
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + rot.y, transform.eulerAngles.z);
            dir.y -= grav * Time.deltaTime;
            charcont.Move(dir * Time.deltaTime);

        }



    }


    public void Transition(playerstate state)
    {
        if (states.Contains(new KeyValuePair<playerstate, playerstate>(currentstate, state)))
        {
            currentstate = state;
        }
        else
            Debug.Log("Transition Doesn't exist");

    }
}
