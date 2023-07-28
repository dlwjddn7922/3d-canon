using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Enemy : MonoBehaviour
{
    private Animator animator;
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * 0.5f);
    }
}
