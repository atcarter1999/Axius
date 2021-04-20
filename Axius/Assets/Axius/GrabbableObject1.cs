using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GrabbableObject1 : MonoBehaviour
{
    public float range = 0f;
    public Transform holdpoint;
    public LayerMask GrabbableLayer;
    private Transform currentlyGrabbedObject;
    public float xPos = 0f;
    public float yPos = 0f;
    public float zPos = 0f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (!currentlyGrabbedObject)
            {
                Collider2D hit = Physics2D.OverlapCircle(transform.position, range, GrabbableLayer);

                if(hit)
                {
                    currentlyGrabbedObject = hit.transform;
                }
            }
            else //release currently grabbed object
            {
                currentlyGrabbedObject = null;
            }
        }

        if(currentlyGrabbedObject)
        {
            Vector3 offset = new Vector3(xPos, yPos, zPos);

            if (Input.GetAxis("Horizontal") < 0)
                xPos = -Math.Abs(xPos);
            else if (Input.GetAxis("Horizontal") > 0)
                xPos = Math.Abs(xPos);

            if (Physics2D.gravity == new Vector2(0, 9.8f))
                yPos = -Math.Abs(yPos);
            else if (Physics2D.gravity == new Vector2(0, -9.8f))
                yPos = Math.Abs(yPos);

            currentlyGrabbedObject.position = holdpoint.position;
            currentlyGrabbedObject.Translate(offset, Space.Self);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (transform == null)
            return;

        Gizmos.DrawWireSphere(transform.position, range);
    }
}