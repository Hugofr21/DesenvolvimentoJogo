using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    [SerializeField]
    private float velocidade;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = transform.up * velocidade;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
