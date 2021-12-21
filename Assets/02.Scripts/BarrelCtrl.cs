using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount = 0;

    void OnCollisionEnter(Collision coll)
    {
        //if (coll.gameObject.tag == "BULLET")
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 1500.0f);
        Destroy(this.gameObject, 2.0f);
    }
}
