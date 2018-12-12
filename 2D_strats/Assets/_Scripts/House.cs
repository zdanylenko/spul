using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour {

    [SerializeField]
    private float team;
    [SerializeField]
    private float money; public float munnie { get { return (money); } set { money = value; } }

    [SerializeField]
    private List<GameObject> army;

    [SerializeField]
    private GameObject spen;
    private List<GameObject> knoppen = new List<GameObject>();

    



    private void Awake()
    {      
        for(int i=0; i<army.Count; i++)
        {
            GameObject boi = Instantiate(spen);
            boi.transform.position = new Vector3(transform.position.x + spen.GetComponent<Renderer>().bounds.size.x * team * i, transform.position.y - gameObject.GetComponent<Renderer>().bounds.size.y, transform.position.z);
            boi.GetComponent<spawner>().unt = army[i];
            knoppen.Add(boi);
        }     
    }
    

    void Update ()
    {
		for(int i=0; i< knoppen.Count; i++)
        {
            if (knoppen[i].GetComponent<spawner>().act)
            {
                if (money >= knoppen[i].GetComponent<spawner>().unt.GetComponent<Unit>().stts.buycl)
                {
                    knoppen[i].GetComponent<spawner>().act = false;
                    money -= knoppen[i].GetComponent<spawner>().unt.GetComponent<Unit>().stts.buycl;
                    GameObject boi = Instantiate(knoppen[i].GetComponent<spawner>().unt);
                    boi.transform.position = new Vector3(transform.position.x + gameObject.GetComponent<Renderer>().bounds.size.x * team, transform.position.y - gameObject.GetComponent<Renderer>().bounds.size.y / 2 + boi.GetComponent<Renderer>().bounds.size.y / 2, transform.position.z);
                }
                else
                {
                    knoppen[i].GetComponent<spawner>().act = false;
                }
            }
        }
   	}


    
}
