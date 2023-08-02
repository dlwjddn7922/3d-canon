using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Enemy : MonoBehaviour
{
    private Animator animator;
    protected float Speed { get; set; }
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * Speed);
    }
}
