using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public  abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Transform hitTranse;
    protected JsonData.EnemyMainData data = new JsonData.EnemyMainData();
    private Animator animator;
    protected float Speed { get; set; }
    protected float HP { get; set; }
    protected int Gold { get; set; }

    public virtual void Init()
    {
        agent.speed = data.speed;
        HP = data.hp;
        Gold = data.gold;
    }
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
            GameObject go = Instantiate(hitEffect);
            go.transform.position = transform.position;
            CatchCheck();
            Destroy(gameObject);
        }
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void CatchCheck()
    {
        EnemySpawnManager.Instance.CatchCount--;

        if (EnemySpawnManager.Instance.CatchCount == 0)
        {
            //UI.Instance.Timer();
            EnemySpawnManager.Instance.Invoke("ReSpawn",0f);

        }
    }
}
