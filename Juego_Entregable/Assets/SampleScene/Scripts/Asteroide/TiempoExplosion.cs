using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoExplosion : MonoBehaviour
{
    [SerializeField] private float duracion;
    public GameObject objeto;
    void Start()
    {
        Destroy(objeto, duracion);
    }
}
