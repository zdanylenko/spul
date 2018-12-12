using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {


    private GameObject unit; public GameObject unt { get { return (unit); } set { unit = value; } }
    private bool active; public bool act { get { return (active); } set { active = value; } }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            active = true;
        }
    }
    
}
