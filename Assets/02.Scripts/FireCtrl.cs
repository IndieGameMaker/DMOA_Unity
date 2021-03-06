#pragma warning disable IDE0051, CS0108

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;

    private AudioSource audio;
    public AudioClip fireSfx;
    public MeshRenderer muzzleFlash;

    private RaycastHit hit;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.gameObject.GetComponentInChildren<MeshRenderer>();
        muzzleFlash.enabled = false;
        //muzzleFlash = firePos.Find("MuzzleFlash").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(firePos.position, firePos.forward * 10.0f, Color.green);

        //왼쪽 마우스 버튼을 클릭할 때마다
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(firePos.position, firePos.forward, out hit, 10.0f, 1 << 8))
            {
                Debug.Log(hit.collider.name);
            }

            Fire();
        }
    }

    void Fire()
    {
        // Instantiate(생성할객체, 좌표, 회전)
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        // 총소리 발생 : PlayOneShot = 소리를 중첩해서 발생
        audio.PlayOneShot(fireSfx, 0.8f);

        // 코루틴 함수 실행
        StartCoroutine(ShowMuzzleFlash());
    }

    IEnumerator ShowMuzzleFlash()
    {
        // Texture Offset 변경 (0, 0) (0, 0.5), (0.5,0) ,(0.5, 0.5)
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        muzzleFlash.material.mainTextureOffset = offset;

        // 회전
        // Quaternion 쿼터니언 (사원수) (x, y, z, w)
        // 짐벌락(Gimbal Lock)
        int angle = Random.Range(0, 360);
        muzzleFlash.transform.localRotation = Quaternion.Euler(0, 0, angle);
        //Quaternion.Euler(Vector3.forward * angle);

        // 스케일
        float scale = Random.Range(1.0f, 3.0f);
        muzzleFlash.transform.localScale = Vector3.one * scale; // new Vector3(scale, scale, scale)

        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(0.2f);
        muzzleFlash.enabled = false;
    }
}
