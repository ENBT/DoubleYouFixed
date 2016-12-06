using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum gamestate
{
    init,
    p1active,
    switching,
    p2active,


}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Player player1, player2;
    bool switchingit;

    CameraManagers cam;
    Vector3 dir = Vector3.zero;
    [SerializeField]
    gamestate state;
    List<KeyValuePair<gamestate, gamestate>> states = new List<KeyValuePair<gamestate, gamestate>>();



    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        switchingit = false;
        states.Add(new KeyValuePair<gamestate, gamestate>(gamestate.init, gamestate.p1active));
        states.Add(new KeyValuePair<gamestate, gamestate>(gamestate.p1active, gamestate.switching));
        states.Add(new KeyValuePair<gamestate, gamestate>(gamestate.switching, gamestate.p1active));
        states.Add(new KeyValuePair<gamestate, gamestate>(gamestate.p2active, gamestate.switching));
        states.Add(new KeyValuePair<gamestate, gamestate>(gamestate.switching, gamestate.p2active));
        cam = FindObjectOfType<CameraManagers>();

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        switch (state)
        {
            case gamestate.init:
                if (!switchingit)
                StartCoroutine(Switchme());
                break;
            case gamestate.p1active:
                if (Inputs.A_Button() && GameManager.Instance.state == game.game)
                    Transition(gamestate.switching);
                setP1Active();
                break;

            case gamestate.p2active:
                if (Inputs.A_Button() && GameManager.Instance.state == game.game)
                    Transition(gamestate.switching);
                setP2Active();
                break;

            case gamestate.switching:
                if (!switchingit)
                    StartCoroutine(Switchme());
                break;
        }


    }


    IEnumerator Switchme()
    {
        switchingit = true;



        if (player1.currentstate == playerstate.active)
        {
            player1.canmove = false;
            yield return StartCoroutine(cam.CameraSwitch(player1));

            if (cam.ready)
            {
                player2.canmove = true;
                switchingit = false;
                Transition(gamestate.p2active);
                yield break;
            }


        }
        if (player2.currentstate == playerstate.active)
        {
            player2.canmove = false;
            yield return StartCoroutine(cam.CameraSwitch(player2));

            if (cam.ready)
            {
                player1.canmove = true;
                switchingit = false;
                Transition(gamestate.p1active);
                yield break;
            }
        }

        if (state == gamestate.init)
        {
           

            if (player2.currentstate == playerstate.init)
            {
                while (player2.currentstate == playerstate.init)
                    yield return null;



            }
            yield return StartCoroutine(cam.CameraSwitch(player2));
            if (cam.ready)
            {
                player1.canmove = true;
                switchingit = false;
                Transition(gamestate.p1active);
                yield break;
            }

        }


    }


    void setP1Active()
    {
        if (player1.currentstate != playerstate.active)
        {
            player1.Transition(playerstate.active);
        }
        if (player2.currentstate != playerstate.inactive)
        {
            player2.Transition(playerstate.inactive);
        }
    }


    void setP2Active()
    {
        if (player1.currentstate != playerstate.inactive)
        {
            player1.Transition(playerstate.inactive);

        }

        if (player2.currentstate != playerstate.active)
        {
            player2.Transition(playerstate.active);
        }

    }

    void Transition(gamestate newstate)
    {
        if (states.Contains(new KeyValuePair<gamestate, gamestate>(state, newstate)))
        {
            state = newstate;
        }
        else
            Debug.Log("Transition does not exist");
    }



}
