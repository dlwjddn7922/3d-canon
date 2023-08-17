using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [HideInInspector]  public Vector3 startPos = Vector3.zero;
    [SerializeField] private Animator animator;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform parent;
    //[SerializeField] private Cannon[] cannons1;
    [HideInInspector] public CannonBlock block;
    //[SerializeField] private Transform cannonBlock;
    CannonBlock startBlock;
    

    RaycastHit hit;
    
    protected float AttDistance { get; set; }
    protected float AttDelay { get; set; }
    protected JsonData.CannonMainData data;
    float attDelayTimer = 0;
    public virtual void Init(int index)
    {
        data = JsonData.Instance.cannonData.cannon[index];
        attDelayTimer = float.MaxValue;
        AttDistance = data.attdistance;
        AttDelay = data.attdelay;
    }
    private void Update()
    {

       Attack();

    }
    public void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(startPos == Vector3.zero)
        {
            startPos = transform.position;
            startBlock = block;
        }
        
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
         {
            Vector3 nextPos = hit.point;
            nextPos.y = transform.position.y;
            transform.position = nextPos;
        }
       
    }
    public void OnMouseUp()
    {
        if (block != null)
        {
            if (block.cannon == null)
            {
                block.cannon = this;
                transform.position = block.transform.position;
                startBlock.cannon = null;

            }
            else
            {
                if(block.cannon.data.name == this.data.name)
                {                   
                    Destroy(block.cannon.gameObject);
                    Destroy(this.gameObject);
                    CannonSpawn.Instance.OnUpgradeCannon();
                }
                Vector3 pos = block.cannon.transform.position;
                block.cannon.transform.position = startPos;
                transform.position = pos;

                Cannon c = block.cannon;
                block.cannon = this;
                startBlock.cannon = c;
            }
        }
        else
        {
            transform.position = startPos;
        }
        startPos = Vector3.zero;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CannonBlock>())
        {
            block = other.GetComponent<CannonBlock>();
            if(block.cannon == null)
                block.Input();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //block.Output();
        block = null;
    }
    Enemy FindEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        float minDis = AttDistance;
        Enemy e = null;
        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (minDis >= distance)
            {
                minDis = distance;
                e = enemy;
            }
        }
        return e;
    }
    void Attack()
    {
        Enemy enemy = FindEnemy();
        if(enemy == null)
        {
            return;
        }

        Vector3 vec = new Vector3(0, enemy.transform.position.y, enemy.transform.position.z);
        transform.LookAt(vec);

        attDelayTimer += Time.deltaTime;
        if(attDelayTimer > AttDelay)
        {
            attDelayTimer = 0f;
            animator.SetTrigger("Attack");

            Ball b = Instantiate(ball, parent);
            b.SetTarget(enemy.transform);
            b.transform.SetParent(null);
            b.Power = data.power;
        }
    }
}
