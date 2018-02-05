using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Ballpool : MonoBehaviour {

    [SerializeField]
    private GameObject poolerd;

    private List<GameObject> allballs = new List<GameObject>(); public List<GameObject> albal { get { return (allballs); } set { allballs = value; } }

    private int maxballs = 0; public int mxbl
    {
        get { return (maxballs); }
        set
        {
            if (maxballs < value)
            {
                while (allballs.Count < value)
                { 
                        GameObject sav = Instantiate(poolerd);
                        allballs.Add(sav);                  
                }
            }else
            if (maxballs > value)
            {
                while (allballs.Count > value)
                { 
                        allballs.RemoveAt(allballs.Count); 
                }
            }
            maxballs = value;
        }
    }

    public GameObject activa()
    {
        bool foundting = false;
        int sevseter = 0;
        for( int i = 0; i < maxballs; i++)
        {
            if (allballs[i].activeSelf != true)
            {
                sevseter = i;
                foundting = true;
                break;
            }
        }
        if (foundting)
        {
            return (allballs[sevseter]);
        }
        else
        {
            return (null);
        }
    }

    public void makestuff(Color cel)
    {
        if (activa() != null)
        {
            GameObject boi = activa();
            activa().SetActive(true);
            activa().GetComponent<_Boll>().col = cel;
        }
    }

    void Start () {
		for(int i = 0; i < maxballs; i++)
        {
            GameObject sav = Instantiate(poolerd);
            allballs.Add(sav);
        }
	}
	
	void Update () {
		
	}
}
