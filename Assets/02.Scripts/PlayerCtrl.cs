using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h;
    private float v;
    private float r;

    public float moveSpeed = 8.0f;
    [Range(50.0f, 100.0f)]
    public float turnSpeed = 80.0f;

    // Animation 컴포넌트를 저장할 변수
    [System.NonSerialized]
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        // 컴포넌트 캐시처리
        anim = this.gameObject.GetComponent<Animation>(); //Generic Syntax : GetComponent<T>()
        // Idle 애니메이션 실행
        anim.Play("Idle");
    }

    // Update is called once per frame
    // Vector3(x, y, z)
    void Update()
    {
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        r = Input.GetAxis("Mouse X");

        // 이동처리
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);  //(전후진벡터) + (좌우벡터)
        transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);
        // 회전처리
        transform.Rotate(Vector3.up * Time.deltaTime * r * turnSpeed);

        // 애니메이션 처리
        PlayerAnim();
    }

    void PlayerAnim()
    {
        if (v >= 0.1f) //전진
        {
            anim.CrossFade("RunF", 0.3f);
        }
        else if (v <= -0.1f) //후진
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if (h >= 0.1f) //오른쪽
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if (h <= -0.1f) //왼쪽
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else
        {
            anim.CrossFade("Idle", 0.3f);
        }
    }

    /* 정규화벡터(Normalized Vector), 유닛벡터(Unit Vector)
    
        Vector3.forward = Vector3(0,0,1)
        Vector3.up      = Vector3(0,1,0)
        Vector3.right   = Vector3(1,0,0)

        Vector3.zero    = Vector3(0,0,0)
        Vector3.one     = Vector3(1,1,1)
    */

}
