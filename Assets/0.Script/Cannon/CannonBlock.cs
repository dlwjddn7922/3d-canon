using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBlock : MonoBehaviour
{

    [HideInInspector] public Cannon cannon = null;
    Vector3 pos;
    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Cannon>())
        {
            if(cannon != null)
            {
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
        if(cannon != null)
        {
            cannon.startPos = pos;
            cannon = null;
        }
    }
}
