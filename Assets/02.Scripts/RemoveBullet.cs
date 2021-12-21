using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            Destroy(coll.gameObject);

            //충돌지점의 좌표
            Vector3 pos = coll.GetContact(0).point;
            //충돌지점의 법선벡터 산출한 후 쿼터니언(사원수) 타입으로 변환
            Quaternion rot = Quaternion.LookRotation(-coll.GetContact(0).normal);

            GameObject spark = Instantiate(sparkEffect, pos, rot);
            Destroy(spark, 0.4f);
        }
    }
}


/*  Call Back Function = Event
    OnCollisionEnter  1
    OnCollisionStay   n
    OnCollisionExit   1
*/