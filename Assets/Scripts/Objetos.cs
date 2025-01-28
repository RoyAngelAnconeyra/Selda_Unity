using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    public enum ObjetosEquipo
    {
        SaludPeque,
        SaludMed,
        Velocidad
    };

    [SerializeField] ObjetosEquipo objetosEquipo;

    public void UsarObjeto()
    {
        Personaje personaje = GameObject.FindObjectOfType<Personaje>();

        switch (objetosEquipo)
        {
            case ObjetosEquipo.SaludPeque:
                personaje.SumaVida();
                Debug.Log("Cura un punto de salud");
                break;
            case ObjetosEquipo.SaludMed:
                Debug.Log("Cura dos puntos de salud");
                break;
            case ObjetosEquipo.Velocidad:
                Debug.Log("Concede velocidad");
                break;
        }

        Destroy(this.gameObject);
    }
}
