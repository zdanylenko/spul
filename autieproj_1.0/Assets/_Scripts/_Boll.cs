using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Boll : MonoBehaviour {

    private Color cols; public Color col { get { return (cols); } set { cols = value; gameObject.GetComponent<SpriteRenderer>().color = value; } }
    private GameObject throwe; public GameObject thrwr { get { return (throwe); } set { throwe = value; } }


	
	// Update is called once per frame
	void Update () {
		
	}
}
