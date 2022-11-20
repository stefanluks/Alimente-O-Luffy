using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuvem : MonoBehaviour
{
    [SerializeField] private float _velocidade = 0.5f;

    void Update()
    {
        transform.position += new Vector3(-1f,0f,0f) * _velocidade * Time.deltaTime;        
    }
}
