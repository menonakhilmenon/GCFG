using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    Animator PlayerAnim;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
       PlayerAnim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Press the up arrow button to reset the trigger and set another one
        if (Input.GetAxis("Vertical") != 0)
        {
          PlayerAnim.SetBool("isRunning",true);
        }
		else
		{
           PlayerAnim.SetBool("isRunning",false);
		}		   
    }
}
