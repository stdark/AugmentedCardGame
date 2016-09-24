using UnityEngine;
using System.Collections;

public class arthuria_button : MonoBehaviour
{
    public Animator obj;

    // Use this for initialization
    public void Click()
    {
        Debug.Log("Button");
        obj.Play("bers_punch");
        
        
    }
}