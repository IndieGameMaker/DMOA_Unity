using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private int hitCount = 0;

    [HideInInspector]
    public new MeshRenderer renderer;

    public Texture[] textures;

    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();

        // 난수발생
        /*
            Random.Range(Min, Max)

            Random.Range(0, 10)   => 0,1,2,3,...,9
            Random.Range(0.0f, 10.0f) => 0.0f , 10.0f
        */

        // 난수 발생
        int idx = Random.Range(0, textures.Length); // 0,1,2
        // 메시렌더러의 머티리얼의 텍스처를 교체
        renderer.material.mainTexture = textures[idx];
    }

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
