using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuracionObjeto : MonoBehaviour
{
    [SerializeField] private float duracion;
    public GameObject objeto;
    void Start()
    {
        Destroy(objeto, duracion);
    }
}
