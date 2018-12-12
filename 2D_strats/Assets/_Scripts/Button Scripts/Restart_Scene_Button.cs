using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart_Scene_Button : MonoBehaviour
{

	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Backspace))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
