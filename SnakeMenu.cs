using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMenu : MonoBehaviour
{
    public void GoToMenu(){
        
        SceneManager.LoadScene("SnakeMenu");

    }
    public void GoToColors(){
        
        SceneManager.LoadScene("Snake-Colors");

    }
    public void GoToFood(){
        SceneManager.LoadScene("Snake-Food");

    }

    public void ExitToCollege(){
        SceneManager.LoadScene("CollegeInner");

    }

    public void GoToMathRunnerGameplay(){
        SceneManager.LoadScene("MathRunner");

    }
}
