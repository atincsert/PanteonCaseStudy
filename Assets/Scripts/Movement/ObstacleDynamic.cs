using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDynamic : MonoBehaviour
{
    [SerializeField] float horizontalSpeed = 3f;
    [SerializeField] float leftBoundary = -2f, rightBoundary = 2f;

    private void Update()
    {
        if (transform.position.x <= leftBoundary)
        {
            MoveObstacle(horizontalSpeed);
        }
        if (transform.position.x >= rightBoundary)
        {
            MoveObstacle(-horizontalSpeed);
        }
    }

    private void MoveObstacle(float leftright)
    { 
        transform.Translate(Vector3.right * Time.deltaTime * leftright);
    }
}
