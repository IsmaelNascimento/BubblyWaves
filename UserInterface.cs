using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void StartGameplay()
    {
        if (PlayerPrefs.GetInt("bInstructions") != 1)
        {
            SceneManager.LoadScene("Instructions");
        }
        else
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    public void Gameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Credits()
    {
        Debug.Log("bInstructions = " + PlayerPrefs.GetInt("bInstructions"));
        SceneManager.LoadScene("Credits");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
