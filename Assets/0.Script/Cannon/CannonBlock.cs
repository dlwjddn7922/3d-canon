using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBlock : MonoBehaviour
{
    public Material[] materials;
    public Cannon cannon = null;
    
    public void Input()
    {
        GetComponent<MeshRenderer>().material = materials[0];
    }
    public void Output()
    {
        GetComponent<MeshRenderer>().material = materials[1];
    }
}
