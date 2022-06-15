using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinyonAi : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] GameObject target;
    [SerializeField] float delta=4;
    Vector3 targetPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");
    }

    void Update()
    {
        SetTargetPosition();
        agent.SetDestination(targetPosition);
    }
    void SetTargetPosition()
    {
        targetPosition=new Vector3(target.transform.position.x,target.transform.position.y, target.transform.position.z-delta);
    }
}
