using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fase1 : MonoBehaviour
{
    [SerializeField] private GameObject _pause;
    [SerializeField] private GameObject _player;
    [SerializeField] private Slider _sliderVida;
    [SerializeField] private Text _txtPontos;
    private int pontos = 1;
    private bool pause = false;

    void Start()
    {
        Time.timeScale = 1f;
        _sliderVida.value = _player.GetComponent<Player>()._vida;
        _player.GetComponent<Player>().pontos = pontos;
        _pause.SetActive(false);
    }

    void Update()
    {
        _sliderVida.value = _player.GetComponent<Player>()._vida;
        pontos = _player.GetComponent<Player>().pontos;
        _txtPontos.text = "Carnes: "+pontos+"/10";
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

    public void Resetar(){
        SceneManager.LoadScene("fase1");
    }

    public void Voltar(){
        SceneManager.LoadScene("Menu");
    }
}
