using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;

    public AudioSource audio;
    public AudioClip fireSfx;

    // Update is called once per frame
    void Update()
    {
        //왼쪽 마우스 버튼을 클릭할 때마다
        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate(생성할객체, 좌표, 회전)
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
