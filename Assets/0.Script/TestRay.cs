using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        //return;
        //마우스 위치로 레이캐스트 쏘기
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.collider.name);

            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
        }
    }   
}
