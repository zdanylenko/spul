using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    private float projspd;
    private float dam;
    private int typ;
    private float tm;

    private void Start()
    {       
        projspd = transform.parent.GetComponent<Attack>().attk.rnspd;
        dam = transform.parent.GetComponent<Attack>().attk.At;
        typ = transform.parent.GetComponent<Attack>().attk.tp;
        tm = transform.parent.GetComponent<Attack>().tem;
        if(tm == 1)
        {
            projspd *= -1;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + projspd, transform.position.y, transform.position.z), 0.22222f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pl1" || other.tag == "pl2")
        {
            if (other.GetComponent<Unit>().stts.Tm != tm)
            {              
                other.GetComponent<Unit>().damage(typ, dam);
                Destroy(gameObject);
            }
        }
    }
}
