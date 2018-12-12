using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Scene_Button : MonoBehaviour
{
    [SerializeField]
    private string scene;

    public void LoadScene_OnButtonClick()
    {
        SceneManager.LoadScene(scene);

    }

}

