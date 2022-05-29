using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticObstacle : MonoBehaviour
{
    [SerializeField] float pushForce = 15f;

    private float characterStartPosZ = -231f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character") || collision.gameObject.CompareTag("Player"))
        {
            Vector3 playerPos = collision.gameObject.transform.position;
            if (collision.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddForce(collision.gameObject.transform.forward * -1 * pushForce, ForceMode.Impulse);

                if (collision.gameObject.CompareTag("Player"))
                {
                    Invoke("ReloadCurrentScene", 0.5f);
                }

                float deadPos = collision.transform.position.z;
                deadPos = characterStartPosZ;
            }

        }
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
