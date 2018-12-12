using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
    [SerializeField]
    private Attacks atk; public Attacks attk { get { return (atk); } set { atk = value; } }
    [SerializeField]
    private GameObject proj;
    private float cooldown; public float  cell{ get{ return(cooldown);}set{ cooldown = value; }}
    private float tm; public float tem { get { return (tm); } set { tm = value; } }
   
    private void Start()
    {      
        transform.parent.GetComponent<Unit>().ateks.Add(this);
        cooldown = 1;
        tm = transform.parent.GetComponent<Unit>().stts.Tm;
        
    }
    private void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
    public bool attackcheck(float Team)
    {
        Vector2 walk;
        if(Team == 0)
        {
            walk = Vector2.right;
        }
        else
        {
            walk = Vector2.left;
        }
        
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + transform.parent.GetComponent<Renderer>().bounds.size.x * walk.x / 2, transform.position.y), walk, atk.Rng, transform.parent.GetComponent<Unit>().stts.Ley);      
        {
            if (hit)
            {               
               // if (hit.collider.GetComponent<Unit>().stts.Tm != transform.parent.GetComponent<Unit>().stts.Tm)
                //{
                    
                    return (true);
                //}
               // else { return (false); }
            }
            else
            {
                return (false);
            }
        }
    }
    public void attacknow(float Team)
    {
        Vector2 walk;
        if (Team == 0)
        {
            walk = Vector2.right;
        }
        else
        {
            walk = Vector2.left;
        }
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x + transform.parent.GetComponent<Renderer>().bounds.size.x * walk.x / 2, transform.position.y, transform.position.z), walk, atk.Rng, transform.parent.GetComponent<Unit>().stts.Ley);
        {
            if (hit)
            {
                if (cooldown <= 0)
                {
                        if (atk.ren)
                        {                           
                            Instantiate(proj, transform.position, transform.rotation, transform);
                        }
                        else
                        {
                        hit.collider.GetComponent<Unit>().damage(atk.tp, atk.At);
                        }                      
                        cooldown = atk.Cd;                  
                }
            }
        }
    }
    private void OnDestroy()
    {
        if(GameObject.Find(transform.parent.name) != null){
           transform.parent.GetComponent<Unit>().ateks.Remove(this);
        }
    }

}
