using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource_Tracker : MonoBehaviour
{
    public int Resource = 10;
    public Text ResourceText;

    void Update()
    {
        ResourceText.text = " Resources: " + " " + Resource.ToString();


        if (Input.GetKey(KeyCode.J))
        {
            Resource -= 1;
        }

        if (Input.GetKey(KeyCode.K))
        {
            Resource += 1;
        }
    }

}
