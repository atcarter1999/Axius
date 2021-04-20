using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform playerTransform;
    public Vector2 spawn;
    public float TopDeathZone = 35;
    public float BottomDeathZone = -20;

    void Update()
    {
        if (playerTransform.position.y < BottomDeathZone || playerTransform.position.y > TopDeathZone)
        {
            playerTransform.position = spawn;
        }
    }
}
