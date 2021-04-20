using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject Door;
    public GameObject Box;
    public float Height = 36.0f;

    // Update is called once per frame
    void Update()
    {
        if (Box.transform.position.y > Height)
            Door.SetActive(false);
        else
            Door.SetActive(true);
    }
}