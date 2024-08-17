using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyancyObject : MonoBehaviour
{
    public Transform[] floaters;

    public float underWaterDrag = 3;
    public float underWaterAngularDrag = 1;
    public float airDrag = 0;
    public float airAngularDrag = 0.05f;
    public float floatingPower = 15f;

    private Rigidbody rb;

    private bool isUnderwater;

    private int floatersUnderwater;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        floatersUnderwater = 0;
        for (int i = 0; i < floaters.Length; i++)
        {
            // Check for any water collisions around the puffer position
            Collider[] hits = Physics.OverlapSphere(floaters[i].position, 0.05f);

            foreach(Collider hit in hits)
            {
                // Check if the collider is on the water layer
                if(hit.gameObject.layer == LayerMask.NameToLayer("Water"))
                {
                    float waterSurfaceY = hit.bounds.center.y; // Get the center y point of the water
                    float difference = floaters[i].position.y - waterSurfaceY;

                    if (difference < 0)
                    {
                        rb.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), floaters[i].position, ForceMode.Force);
                        floatersUnderwater += 1;
                        if (!isUnderwater)
                        {
                            isUnderwater = true;
                            SwitchState(true);
                        }
                    }
                }
            }       
        }

        if (isUnderwater && floatersUnderwater == 0)
        {
            isUnderwater = false;
            SwitchState(false);
        }
    }

    private void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            rb.drag = underWaterDrag;
            rb.angularDrag = underWaterAngularDrag;
        }
        else
        {
            rb.drag = airDrag;
            rb.angularDrag = airAngularDrag;
        }
    }

}
