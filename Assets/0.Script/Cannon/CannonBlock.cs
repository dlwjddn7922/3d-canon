using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBlock : MonoBehaviour
{

    [HideInInspector] public Cannon cannon = null;
    /*
    Vector3 pos;
    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Cannon>())
        {
            //기존에 있던 캐논
            if(cannon != null)
            {
                //cannon.transform.position = other.GetComponent<Cannon>().startPos;
                return;
            }
            cannon = other.GetComponent<Cannon>();
            pos = cannon.startPos;
            Vector3 vec = transform.position;
            vec.y = cannon.startPos.y;
            cannon.startPos = vec;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if(cannon == other.gameObject.GetComponent<Cannon>())
        {
            if (cannon != null)
            {
                //cannon.startPos = pos;
                cannon = null;
            }
        }     
    }*/
}
