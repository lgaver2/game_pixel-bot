using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dead : MonoBehaviour
{
    // Start is called before the first frame update

  
    AudioSource aud;
    Rigidbody2D rigid;

    
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    
}
