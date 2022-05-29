using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 3f;
    [SerializeField] float swerveSpeed = 0.5f;
    [SerializeField] float maxSwerve = 2.5f;

    public event Action OnCameraPriorityChanged;

    private Rigidbody rb;
    private bool isStuck;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {       
        if (isStuck == true) return;
        ForwardMovement();
        SwerveMovement();
    }

    private void ForwardMovement()
    {   
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
    }

    private void SwerveMovement()
    {
        if (!Input.GetMouseButton(0)) return;
        float additionalVector = Input.GetAxisRaw("Horizontal") * Time.deltaTime * swerveSpeed;
        float finalPosX = Mathf.Clamp(transform.position.x + additionalVector, -maxSwerve, maxSwerve);
        transform.position = new Vector3(finalPosX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.GetComponent<StaticObstacle>() != null ||
            collision.gameObject.GetComponent<DynamicObstacleMovement>() != null ||
            collision.gameObject.GetComponent<HalfDonutMover>() != null)
        {
            // ANÝM
            isStuck = true;
            rb.AddForce(transform.forward * -1, ForceMode.Impulse);
        }
    }
    
    // TODO : scenemanagement baþa döndüðünde amIStuckBruh = false again.

}
