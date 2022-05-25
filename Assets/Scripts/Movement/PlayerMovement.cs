using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float swerveSpeed = 0.5f;
    [SerializeField] float maxSwerve = 4f;

    private SwerveInput swerveInput;

    private void Awake()
    {
        swerveInput = GetComponent<SwerveInput>();
    }
    private void Update()
    {
        MoveForward();
        SwerveMovement();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void SwerveMovement()
    {
        float swerveAmount = swerveInput.DisplacementX * Time.deltaTime * swerveSpeed;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerve, maxSwerve);
        transform.Translate(swerveAmount, 0, 0);
    }
    //public float DisplacementValue()
    //{
    //    return displacementX;
    //}
}
