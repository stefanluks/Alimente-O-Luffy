using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jogar(){
        SceneManager.LoadScene("fase1");
    }

    public void Sair(){
        Application.Quit();
    }
}
