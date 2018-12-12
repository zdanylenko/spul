using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class _Boll : MonoBehaviour {

    private Color cols; public Color col { get { return (cols); } set { cols = value; gameObject.GetComponent<SpriteRenderer>().color = value; } }
    private Vector3 throwe; public Vector3 thrwr { get { return (throwe); } set { throwe = value; } }
    private bool held; public bool dragging { get { return (held); } set { held = value; } }

    public SpringJoint2D spring;

    void Awake()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / Random.RandomRange(1.5f,2), Screen.height / Random.RandomRange(1.5f, 2), Camera.main.farClipPlane - 0.5f));
        spring = this.gameObject.GetComponent<SpringJoint2D>();
        spring.connectedAnchor = gameObject.transform.position;
    }
        // Update is called once per frame
        void Update () {

        /*
        if (held)
        {
            transform.position = throwe;
        }
        */
        
	}
    

    private void OnMouseOver()
    {
        /*
        if (Input.GetMouseButtonDown(0)){
            if(held != true)
            {
                held = true;
            }
        }
        */
    }

    private void OnMouseDown()
    {
        spring.enabled = true;
    }
    private void OnMouseDrag()
    {


        if (spring.enabled == true)
        {

            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spring.connectedAnchor = cursorPosition;
        }
    }
    private void OnMouseUp()
    {
        spring.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "walski (1)" || collision.name == "walski" || collision.name == "walski (2)" || collision.name == "walski (3)")
        {
            GameObject.Find("balpol(Clone)").GetComponent<_Ballpool>().unmakestuff(gameObject);
        }
    }

}
