using UnityEngine;
using System.Collections;




public class InteractableObject : MonoBehaviour
{
    public int id; 

    public const int Hold = 1; // Objects that you hold such as Boxes
    public const int Trigger = 2; // Objects that are activated by contact with other objects such as Floor Triggers
    public const int Activate = 3; // Objects that you turn on and off such as Levers and Buttons
    public const int Switch = 4; // Objects that are activated by the activation of other objects such as Doors and Block spawners.


    public int type;



    public bool isActive;

    virtual public void StartInteract(Player p) { }
    
    virtual public void StopInteract() { }




}

