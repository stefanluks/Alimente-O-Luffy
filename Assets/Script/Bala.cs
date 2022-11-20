using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private int _velocidade = 5;
    [SerializeField] private float _direcao = -1f;
    private Transform player;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(player.position.x > transform.position.x){
            _direcao = 1f;
        }else{
            _direcao = -1f;
        }
    }

    void Update()
    {
        transform.position += new Vector3(_direcao,0f, 0f) * _velocidade * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            Destroy(gameObject);
            other.gameObject.GetComponent<Player>()._vida -= 10;
        }
    }
}
