using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public NPCDataSO datos; //Se asigna cuando llega el cliente
    public SpriteRenderer renderOjos, renderMascara;
    private bool usandoLupa = false;
    private Vector3 posicionOriginal;

    // Start is called before the first frame update
    void Start() => posicionOriginal = transform.localPosition;
    
    public void Configurar(NPCDataSO nuevosDatos)
    {
        datos = nuevosDatos;
        renderOjos.sprite = datos.rasgoOcularAsignado.spritePupila;
        renderOjos.color = datos.rasgoOcularAsignado.colorOjo;
        renderMascara.sprite = datos.mascaraEquipada.spriteMascara;

    }

    // Update is called once per frame
   /* void Update()
    {
        if(datos == null) return;

        float intensidad = datos.razaReal.vibracionBase;

        if(usandoLupa)
            intensidad *= datos.reaccionAsignada.multiplicadorTemblor;

        if(intensidad > 0)
        {
             transform.localPosition = posicionOriginal + (Vector3)Random.insideUnitCircle * intensidad; 
        }
    }*/

    //Estos métodos los llamarías desde tu sistema de herramientas (Lupa)
    public void ActivarLupa() => usandoLupa = true;
    public void DesactivarLupa() => usandoLupa = false;
}
