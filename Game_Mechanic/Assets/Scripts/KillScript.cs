using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death") && !other.CompareTag("Jim"))
        {
            Destroy(gameObject);
            Application.LoadLevel("Game_Over");
        }
    }
}

