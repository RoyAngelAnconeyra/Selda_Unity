using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] private float velocidad;
    //[SerializeField] private BoxCollider2D colEspada;

    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer spritePersonaje;
    private int vidaPersonaje = 3;
    private bool estoyHablando;

    [SerializeField] UIManager uIManager;

    //private float posColX = 1;
    //private float posColY = 0;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        spritePersonaje = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && estoyHablando == false)
        {
            anim.SetTrigger("Ataca");
        }
        
        if(Input.GetKeyDown(KeyCode.K))
        {
            CausarHerida();
        }
    

    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    public void ChequearSiHablo (bool hablando)
    {
        estoyHablando = hablando;
    }
    
    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(estoyHablando == false){
            rig.velocity = new Vector2(horizontal, vertical)* velocidad;
            anim.SetFloat("Camina",Mathf.Abs(rig.velocity.magnitude));
        }

        if(horizontal >0)
        {
            //colEspada.offset = new Vector2(posColX, posColY);
            spritePersonaje.flipX = false;
        }
        else if(horizontal <0)
        {
            //colEspada.offset = new Vector2(-posColX, posColY);
            spritePersonaje.flipX = true;
        }
    }

    private void CausarHerida()
    {
        if(vidaPersonaje > 0)
        {
            vidaPersonaje--;
            uIManager.RestaCorazones(vidaPersonaje);
            if (vidaPersonaje == 0)
            {
                anim.SetTrigger("Muere");
                Invoke(nameof(Morir), 1f);
            }
        }
    }

    public void SumaVida()
    {
        if(vidaPersonaje <3)
        {
            uIManager.SumaCorazones(vidaPersonaje);
            vidaPersonaje++;
        }
    }

    private void Morir()
    {
        Destroy(this.gameObject);
    }
}
