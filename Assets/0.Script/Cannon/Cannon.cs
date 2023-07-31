using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    [HideInInspector] public bool isDrag = false;
    [HideInInspector]  public Vector3 startPos = Vector3.zero;
    [SerializeField] private Transform target;
    [SerializeField] private Animator animator;
    [HideInInspector] public CannonBlock block;
    RaycastHit hit;


    private void Update()
    {
        transform.LookAt(target);

        if(Input.GetKeyDown(KeyCode.F1))
        {
            animator.SetTrigger("Attack");
        }
    }
    public void OnMouseDrag()
    {
        isDrag = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(startPos == Vector3.zero)
        {
            startPos = transform.position;
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
            if (block.cannon == null || block.cannon == this)
            {
                block.cannon = this;
                transform.position = block.transform.position;
                block = null;
            }
            else
            {
                Vector3 pos = block.cannon.transform.position;
                block.cannon.transform.position = startPos;
                transform.position = pos;
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
            if(block.cannon != null)
                block.cannon = this;
            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(block != null && block.cannon == null)
        {
            block = null;
            if (other.GetComponent<CannonBlock>())
            {
                other.GetComponent<CannonBlock>().cannon = null;
            }
        }

    }
}
