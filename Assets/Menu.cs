using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void play0(){
        SceneManager.LoadScene(0);
    }
    public void play(){
        SceneManager.LoadScene(1);
    }
public void play2(){
        SceneManager.LoadScene(2);
    }
    public void play3(){
        SceneManager.LoadScene(3);
    }
    public void play4(){
        SceneManager.LoadScene(4);
    }
    public void play5(){
        SceneManager.LoadScene(5);
    }
    public void play6(){
        SceneManager.LoadScene(6);
    }
    public void play7(){
        SceneManager.LoadScene(7);
    }
    public void Exit(){
        Application.Quit();
    }
}
