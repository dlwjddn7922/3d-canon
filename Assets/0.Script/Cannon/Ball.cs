using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * 5f); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.GetMask("Ground") == 64)
        {
            Destroy(gameObject);
        }
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
