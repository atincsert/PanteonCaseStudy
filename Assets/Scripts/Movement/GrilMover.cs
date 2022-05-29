using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilMover : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 3f;
    [SerializeField] float swerveSpeed = 0.5f;
    //[SerializeField] float lerpSpeed = 0.5f;
    //[SerializeField] float playerXDisplacement = 2f;
    //[SerializeField] Vector2 maxSwerve = new Vector2(-2.5f ,2.5f);
    [SerializeField] float maxSwerve = 2.5f;

    //public event Action OnCameraPriorityChanged;

    //private SwerveInput swerveInput;
    private Rigidbody rb;
    private float newXPos;
    private float startingXPos;
    private bool isRotating = false;
    private bool amIStuckBruh;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //swerveInput = GetComponent<SwerveInput>();
    }

    private void Start()
    {
        //startingXPos = transform.position.x;
    }
    private void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    startingXPos = Mathf.Clamp(transform.position.x + Input.GetAxisRaw("Horizontal") * playerXDisplacement,
        //        startingXPos + maxSwerve.x, startingXPos + maxSwerve.y);
        //}
        if (amIStuckBruh == true) return;
        ForwardMovement();
        //SwerveMovement();
    }

    private void FixedUpdate()
    {
        //Movement();
    }

    private void ForwardMovement()
    {
        //rb.MovePosition(new Vector3(Mathf.Lerp(transform.position.x ,newXPos, lerpSpeed * Time.fixedDeltaTime),
        //    rb.velocity.y, transform.position.z + forwardSpeed * Time.fixedDeltaTime));     
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
    }

    private void SwerveMovement()
    {
        //float additionalVector = Input.GetAxisRaw("Horizontal") * Time.deltaTime * swerveSpeed;
        float finalPosX = Mathf.Clamp(transform.position.x + 10f * Time.deltaTime * swerveSpeed, -maxSwerve, maxSwerve);
        transform.position = new Vector3(finalPosX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<StaticObstacle>() != null ||
            collision.gameObject.GetComponent<DynamicObstacleMovement>() != null ||
            collision.gameObject.GetComponent<HalfDonutMover>() != null)
        {
            // ANÝM
            amIStuckBruh = true;
            rb.AddForce(transform.forward * -1, ForceMode.Impulse);
        }
    }

    // TODO : scenemanagement baþa döndüðünde amIStuckBruh = false again.
}
