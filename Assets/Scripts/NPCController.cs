using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public NPCDataSO datos; //Se asigna cuando llega el cliente
    private bool usandoLupa = false;
    private Vector3 posicionOriginal;

    // Start is called before the first frame update
    void Start() => posicionOriginal = transform.localPosition;
    

    // Update is called once per frame
    void Update()
    {
        float intensidad = datos.razaReal.vibracionBase;

        if(usandoLupa)
            intensidad *= datos.reaccionAsignada.multiplicadorTemblor;

        if(intensidad > 0 && !datos.razaReal.esRigido)
        {
            float x = Random.Range(-1f, 1f) * intensidad;
            float y = Random.Range(-1f, 1f) * intensidad;
            transform.localPosition = posicionOriginal + new Vector3(x, y, 0); 
        }
    }

    //Estos métodos los llamarías desde tu sistema de herramientas (Lupa)
    public void ActivarLupa() => usandoLupa = true;
    public void DesactivarLupa() => usandoLupa = false;
}
