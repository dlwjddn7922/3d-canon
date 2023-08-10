using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public  abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;
    protected JsonData.EnemyMainData data = new JsonData.EnemyMainData();
    private Animator animator;
    protected float Speed { get; set; }
    protected float HP { get; set; }
    protected int Gold { get; set; }
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
            UI.Instance.Life--;
            Destroy(gameObject);
        }
    }
    public void Hit(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            UI.Instance.Gold += Gold;
            EnemySpawnManager.Instance.CatchCount--;

            if (EnemySpawnManager.Instance.CatchCount == 0)
            {
                EnemySpawnManager.Instance.Invoke("ReSpawn", 5f);              
                
            }
            Destroy(gameObject);
        }
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
