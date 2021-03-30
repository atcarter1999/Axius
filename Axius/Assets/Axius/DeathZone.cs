using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform playerTransform;
    public Vector2 spawn;

    void Update()
    {
        if (playerTransform.position.y < -20 || playerTransform.position.y > 35)
        {
            playerTransform.position = spawn;
        }
    }
}
