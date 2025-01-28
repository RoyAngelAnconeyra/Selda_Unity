using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTextos : MonoBehaviour
{
    [SerializeField, TextArea(3,10)] private string [] arrayTextos;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private Personaje personaje;
    
    private int indice;

    private void Awake()
    {
        personaje = GameObject.FindGameObjectWithTag("Player").GetComponent<Personaje>();
        if (uIManager == null)
        {
            uIManager = FindObjectOfType<UIManager>();
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Haciendo clic en el objeto Textos.");
        float distancia = Vector2.Distance(this.gameObject.transform.position, personaje.transform.position);
        Debug.Log("Distancia al personaje: " + distancia);
        if(distancia <= 3)
        {
            Debug.Log("El personaje está cerca. Mostrando texto.");
            uIManager.ActivaDesactivaCajaTextos(true);
            personaje.ChequearSiHablo(true);
            ActivaCartel();
        }
    }

    void ActivaCartel()
    {
        if(indice < arrayTextos.Length)
        {
            uIManager.MostrarTextos(arrayTextos[indice]);
            indice++;
        }
        else
        {
            uIManager.ActivaDesactivaCajaTextos(false);
            personaje.ChequearSiHablo(false);
        }
    }
}
