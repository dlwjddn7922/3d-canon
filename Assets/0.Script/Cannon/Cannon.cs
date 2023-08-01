using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [HideInInspector]  public Vector3 startPos = Vector3.zero;
    [SerializeField] private Transform target;
    [SerializeField] private Animator animator;
    [HideInInspector] public CannonBlock block;
    CannonBlock startBlock;

    RaycastHit hit;
    float attDistance = 2f;
    float attDelay = 0.5f;
    float attDelayTimer = 0f;
    private void Update()
    {
        Attack();
        if(Input.GetKeyDown(KeyCode.F1))
        {
            animator.SetTrigger("Attack");
        }
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
                startBlock = null;
            }
            else
            {
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
    void PositionChange()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CannonBlock>())
        {
            block = other.GetComponent<CannonBlock>();            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        block = null;
    }
    Enemy FindEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        float minDis = attDistance;
        Enemy e = null;
        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (minDis <= distance)
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

        transform.LookAt(enemy.transform);

        attDelayTimer += Time.deltaTime;
        if(attDelayTimer > attDelay)
        {
            attDelayTimer = 0f;
            animator.SetTrigger("Attack");
        }
    }
}
