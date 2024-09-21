using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    Collider2D col;
    byte[] color = { 255, 255, 255 };
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }
    public void trigger(bool t)
    {
        col.isTrigger = t;
    }
   
}
