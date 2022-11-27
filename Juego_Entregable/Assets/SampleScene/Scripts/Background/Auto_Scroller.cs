using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Scroller : MonoBehaviour
{
    public float scrollSpeed;
    [SerializeField] private MeshRenderer mesh;

    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * scrollSpeed);
        mesh.material.mainTextureOffset = offset;
    }
}
