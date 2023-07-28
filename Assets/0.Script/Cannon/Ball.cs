using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 destination = new Vector3(0, -6, 3);
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, destination,  Time.deltaTime * 0.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.GetMask("Ground") == 64)
        {
            Destroy(gameObject);
        }
    }
}
