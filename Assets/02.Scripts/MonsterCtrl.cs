using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Navigation 컴포넌트의 네임스페이스

public class MonsterCtrl : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerTr; // 주인공 캐릭터의 Transform
    public Transform monsterTr;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
