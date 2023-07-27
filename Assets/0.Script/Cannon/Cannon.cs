using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    [HideInInspector] public bool isDrag = false;
    RaycastHit hit;
    [HideInInspector]  public Vector3 startPos = Vector3.zero;
    [SerializeField] Transform target;
    [SerializeField] private Animator animator;

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
        transform.position = startPos;
        startPos = Vector3.zero;
    }

}
