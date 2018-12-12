using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    
    private float heatlth = 100; public float hp { get { return (hp); } set { hp = value;   } }
    private bool dead = false; public bool ded { get { return (dead); } set { dead = value; } }

	void Update () {
		if(heatlth <= 0)
        {
            dead = true;
        }
        else { dead = false; }
	}
}
