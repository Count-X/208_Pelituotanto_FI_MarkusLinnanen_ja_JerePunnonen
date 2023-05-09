using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // You can call this function with a button and set the parameter i in the button OnClick()
    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
