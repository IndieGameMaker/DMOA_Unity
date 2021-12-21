using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Navigation 컴포넌트의 네임스페이스

public class MonsterCtrl : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform playerTr; // 주인공 캐릭터의 Transform
    public Transform monsterTr;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        monsterTr = GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<Transform>();

        // GameObject playerObj = GameObject.FindGameObjectWithTag("PLAYER");
        // if (playerObj != null)
        // {
        //     playerTr = playerObj.GetComponent<Transform>();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTr == null) return;

        agent.SetDestination(playerTr.position);
        anim.SetBool("IsTrace", true);
    }
}
