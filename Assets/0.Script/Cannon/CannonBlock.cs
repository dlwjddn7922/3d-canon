using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Cannon cannon;
    Vector3 pos;
    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Cannon>())
        {
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
