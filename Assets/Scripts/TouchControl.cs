using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{

    public void OnLeftPressed()
    {
        CarController.steerinput = -0.7f;

    }

    public void OnRightPressed()
    {
        CarController.steerinput = 0.7f;

    }
    public void Released()
    {
        CarController.steerinput = 0;


    }
   
}
