using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Ballpool : MonoBehaviour {

    [SerializeField]
    private GameObject poolerd;

    private List<GameObject> allballs = new List<GameObject>(); public List<GameObject> albal { get { return (allballs); } set { allballs = value; } }

    
    private int maxballs = 5; public int mxbl
    {
        get { return (maxballs); }
        set
        {
            if (maxballs < value)
            {
                while (allballs.Count < value)
                { 
                        GameObject sav = Instantiate(poolerd);
                    sav.SetActive(false);
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
    public bool boi()
    {
        bool bojo = true;
        for(int i=0; i<maxballs; i++)
        {
            if (allballs[i].activeSelf)
            {
                bojo = false;
            }
        }
        return (bojo);
    }
    

    public void makestuff(Color cel, Vector3 poski)
    {
        if (activa() != null)
        {
            GameObject boi = activa();
            if (boi != null)
            {
                boi.SetActive(true);
                boi.GetComponent<_Boll>().col = cel;
                boi.transform.position = poski;
            }
        }
    }
    public void unmakestuff(GameObject bjol)
    {
        bjol.transform.position = transform.position;
        bjol.SetActive(false);
    }
    public void unmakeall()
    {
        for(int i=0; i<allballs.Count; i++)
        {
            allballs[i].transform.position = transform.position;
            allballs[i].SetActive(false);
            
        }
    }

    void Start () {
		for(int i = 0; i < maxballs; i++)
        {
            GameObject sav = Instantiate(poolerd);
            sav.SetActive(false);
            
            allballs.Add(sav);
        }
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.G))
        {
            makestuff(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f), new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.farClipPlane));
        }
	}
}
