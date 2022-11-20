using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marinheiro : MonoBehaviour
{
    [SerializeField] private int _velocidade = 5;
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _render;
    [SerializeField] private GameObject _disparo, _bala;
    private bool atacando = false;
    public bool _vivo = true;
    private int _tempo = 200, _cont = 180;
    private Transform seguir;

    void Start(){
        _anim = GetComponent<Animator>();
        _render = GetComponent<SpriteRenderer>();
        seguir = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    void Update()
    {
        if(_vivo){
            if(seguir.position.x > transform.position.x){
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }else{
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
            if(!atacando){
                transform.position = Vector2.MoveTowards(transform.position, seguir.position, _velocidade * Time.deltaTime);
            }else{
                if(_cont < _tempo ){
                    _cont++;
                }else{
                    _cont=0;
                    Disparar();
                    _anim.SetTrigger("atacando");
                }
            }
        }else{
            if(_cont < _tempo ){
                _cont++;
            }else{
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            atacando = true;
            _anim.SetBool("ataque",true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            atacando = false;
            _anim.SetBool("ataque",false);
        }
    }

    void Disparar(){
        Instantiate(_bala,_disparo.transform.position,Quaternion.identity);
    }
}
