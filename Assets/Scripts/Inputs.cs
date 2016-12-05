using UnityEngine;
using System.Collections;

public class Inputs {   

    public static float HorizontalAxis()
    {
        float r = 0.0f;
        //r += Input.GetAxis("J_Horizontal");
        r += Input.GetAxis("K_Horizontal");
        return Mathf.Clamp(r, -1f, 1f);
    }
    public static float VerticalAxis()
    {
        float r = 0.0f;
        //r += Input.GetAxis("J_Vertical");
        r += Input.GetAxis("K_Vertical");
        return Mathf.Clamp(r, -1f, 1f);
    }


    public static bool A_Button()
    {
        return Input.GetButtonDown("A_Button");
    }

    public static bool B_Button()
    {
        return Input.GetButtonDown("B_Button");
    }


    public static float CamHorizontalAxis()
    {
        float r = 0.0f;
        r += Input.GetAxis("K_R_Horizontal");

        return Mathf.Clamp(r, -1f, 1f);
    }

    public static float CamVerticalAxis()
    {
        float r = 0.0f;
        r += Input.GetAxis("K_R_Vertical");
        return Mathf.Clamp(r, -1, 1f);
    }



}
