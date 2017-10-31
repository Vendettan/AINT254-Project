using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour {

    [SerializeField]
    private Transform player;

    private float smoothing = 5.0f;

    private void FixedUpdate()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y, -20);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * Time.fixedDeltaTime));        
    }



}
