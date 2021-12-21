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
        //왼쪽 마우스 버튼을 클릭할 때마다
        if (Input.GetMouseButtonDown(0))
        {
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
        muzzleFlash.enabled = true;
        yield return new WaitForSeconds(0.2f);
        muzzleFlash.enabled = false;
    }
}
