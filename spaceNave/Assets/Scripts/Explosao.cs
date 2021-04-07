using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour
{

    [SerializeField]
    private float tempo;

    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<AudioSource>()!= null){
        
        GetComponent<AudioSource>().Play();
        Destroy(gameObject,tempo);
        
        }
    }

    
}
