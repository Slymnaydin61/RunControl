using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinyonAi : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
    }
}
