using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Credits;
    public GameObject Title;

    public enum State
    {
        Title,
        Credits,

    }

    public State MenuState = State.Title;

    private void Start()
    {
        MenuState = State.Title;
    }

    private void Update()
    {
        switch (MenuState)
        {
            case State.Title:
                Credits.SetActive(false);
                Title.SetActive(true); break;
            case State.Credits:
                Credits.SetActive(true);
                Title.SetActive(false); break;

        }

    }

    // You can call this function with a button and set the parameter i in the button OnClick()
    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void ChangeState(int s)
    {
        MenuState = (State)s;
    }
}
