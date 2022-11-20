using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fase2 : MonoBehaviour
{
    [SerializeField] private GameObject _marinheiro;
    [SerializeField] private List<GameObject> _lista;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Slider _sliderVida;
    [SerializeField] private Text _txtPontos;
    private int pontos = 0;
    private bool pause = false;

    void Start(){
        Time.timeScale = 1f;
        _lista = new List<GameObject>();
        _sliderVida.value = _player.GetComponent<Player>()._vida;
        _player.GetComponent<Player>().pontos = pontos;
        _pause.SetActive(false);
    }

    void Update(){
        _sliderVida.value = _player.GetComponent<Player>()._vida;
        pontos = _player.GetComponent<Player>().pontos;
        _txtPontos.text = "Pontos: "+pontos;
        if(_lista.Count == 0){
            GameObject novo = Instantiate(_marinheiro, _spawn.position, Quaternion.identity);
            _lista.Add(novo);
        }else{
            foreach (GameObject marinheiro in _lista)
            {
                if(!marinheiro){
                    _lista.Remove(marinheiro);
                }
            }
        }
        if(_player.GetComponent<Player>()._vida <= 0){
            GameOver();
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            pause = !pause;
            _pause.SetActive(pause);
        }
        if(pause){
            Time.timeScale= 0f;
        }else{
            Time.timeScale= 1f;
        }
    }

    void GameOver(){
        _gameOver.SetActive(true);
        Invoke("pausar",0.8f);
    }

    void pausar(){
        Time.timeScale = 0f;
    }

    public void Resetar(){
        SceneManager.LoadScene("fase2");
    }

    public void Voltar(){
        SceneManager.LoadScene("Menu");
    }
}
