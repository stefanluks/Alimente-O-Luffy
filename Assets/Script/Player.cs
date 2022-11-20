using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _velocidade = 5, _forcaPulo = 8;
    [SerializeField] private Animator _anim;
    [SerializeField] private Rigidbody2D _rig;
    [SerializeField] private SpriteRenderer _render;

    public int  _vida = 10, pontos=0;
    private bool atacando = false, EstaNoChao=false;

    void Start(){
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
        _anim = GetComponent<Animator>();
        _rig = GetComponent<Rigidbody2D>();
        _render = GetComponent<SpriteRenderer>();
    }

    void Update(){
        Controles();
    }

    void Controles(){
        float direcao = 0f;
        if(Input.GetKey(KeyCode.A)){
            _render.flipX = true;
            direcao = -1f;
        }
        if(Input.GetKey(KeyCode.D)){
            _render.flipX = false;
            direcao = 1f;
        }
        if(direcao != 0f){
            _anim.SetBool("correndo", true);
        }else{
            _anim.SetBool("correndo", false);
        }
        transform.position += new Vector3(direcao, 0f, 0f) * _velocidade * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && EstaNoChao){
            EstaNoChao = false;
            _anim.SetBool("EstaNoChao", false);
            _rig.AddForce(transform.up * _forcaPulo, ForceMode2D.Impulse);
        }
        if(Input.GetKeyDown(KeyCode.K) && EstaNoChao){
            _anim.SetTrigger("ataque1");
            atacando = true;
            Invoke("Atacando",0.8f);
        }
        if(Input.GetKeyDown(KeyCode.L) && EstaNoChao){
            _anim.SetTrigger("ataque2");
            atacando = true;
            Invoke("Atacando",0.8f);
        }
        if(Input.GetKeyDown(KeyCode.Return) && _vida == 100){
            SceneManager.LoadScene("fase2");
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "chao"){
            EstaNoChao = true;
            _anim.SetBool("EstaNoChao", true);
        }
        if(other.gameObject.tag == "inimigo" && atacando){
            other.gameObject.GetComponent<Animator>().SetTrigger("morreu");
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale=0;
            other.gameObject.GetComponent<Marinheiro>()._vivo = false;
            pontos++;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "carne"){
            pontos++;
            _vida+=10;
            Destroy(other.gameObject);
        }
    }

    void Atacando(){
        atacando = false;
    }
}
