using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    //audio
    private AudioSource audioSource;

    //movimento
    private float moverHorizontal;
    private float moverVertical;
    private Vector2 mover;
    private Rigidbody2D rb2d;

    //bomba
    [SerializeField]
    private GameObject instanciarBombas;
    [SerializeField]
    private GameObject prefabBomba;
    private float controle;
    [SerializeField]
    private float atirarTempo;

    [SerializeField]
    private float velocidade;

    // posicao dos meus eixos de colisao
    private float eixoXMin, eixoXMax;
    private float eixoYMin, eixoYMax;
    //posicao do meu rigidBody2D
    private float posicaoX, posicaoY;

    // Use this for initialization
    void Start()
    {
        //bomba
        controle = 0f;

        //obrer CameraPrincipal
        eixoXMax = CameraPrincipal.LimitarDireitaX(transform.position);
        eixoXMin = CameraPrincipal.LimitarEsquerdaX(transform.position);
        eixoYMax = CameraPrincipal.LimitarParaCimaY(transform.position);
        eixoYMin = CameraPrincipal.LimitarParaBaixoY(transform.position);

        //Player
        rb2d = GetComponent<Rigidbody2D>();
        //audio
        audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        moverVertical = Input.GetAxis("Vertical");
        mover = new Vector2(moverHorizontal, moverVertical);
        rb2d.velocity = mover * velocidade;

        //Debug.Log(rb2d.velocity);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time > controle)
            {
                controle = Time.time + atirarTempo;

                //objet + onde sai a bomba + buscar a rotacao
                Instantiate(prefabBomba, instanciarBombas.transform.position, prefabBomba.transform.rotation);


                audioSource.Play();
            }
          
        }

        LimitarPosicaoPlayer();
    }


    void LimitarPosicaoPlayer()
    {
        posicaoX = rb2d.position.x; //transform.position.x;
        posicaoY = rb2d.position.y;

        //posicao maxima e minima de cada eixo
        posicaoX = Mathf.Clamp(posicaoX, eixoXMin, eixoXMax);
        posicaoY = Mathf.Clamp(posicaoY, eixoYMin, eixoYMax);

        if(posicaoX != transform.position.x)
        {
            rb2d.position = new Vector2(posicaoX, rb2d.position.y);

        }

        if (posicaoY != transform.position.y)
        {
            rb2d.position = new Vector2(rb2d.position.x, posicaoY);

        }

    }

    void GanharVida(Collider2D outro){
        if(outro.tag=="Energia"){

        }

    }

    void PerderVida(Collider2D outro){
        
        if(outro.tag == "Asteroide" || outro.tag == "Inimigo"){
            
        }

    }
}
