using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInput : MonoBehaviour
{
    private float lastPosX;
    private float displacementX;
    public float DisplacementX => displacementX;

    private void Update()
    {
        InputForSwerve();
    }
    public void InputForSwerve()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            displacementX = Input.mousePosition.x - lastPosX;
            lastPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            displacementX = 0;
        }
    }
}
