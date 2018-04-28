using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{

    private NavMeshAgent nav;
    private Transform player;
    //public Transform enemeyPos;
    public float attackDistance = 20;
    // Use this for initialization
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    // Update is called once per frame
    void Update()
    {
        if ((this.player.position.magnitude - transform.position.magnitude) < this.attackDistance)
        {
            nav.SetDestination(player.position);
        }
    }

}
