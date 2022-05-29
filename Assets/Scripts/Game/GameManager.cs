using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnFinish?.Invoke();
            other.gameObject.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
