using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public  abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;
    private Animator animator;
    protected float Speed { get; set; }
    protected float HP { get; set; }
    private void Update()
    {
        if(target == null)
        {
            return;
        }
         
        if(HP != 0)
            agent.SetDestination(target.position);
        else
            agent.SetDestination(transform.position);

        float distance = Vector3.Distance(transform.position, target.position);
        if(agent.stoppingDistance >= (int)distance)
        {
            Destroy(gameObject);
        }
    }
    public void Hit(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
