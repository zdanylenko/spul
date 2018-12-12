using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Handler : MonoBehaviour {
    [SerializeField]
    private GameObject backgrnd;
    [SerializeField]
    private GameObject blpel;
    [SerializeField]
    private int ding;
    private List<GameObject> plers;
    [SerializeField]
    private int lpl;
    private LineRenderer lerder;
    private int bloppo =0;
    private List<Image> sprets = new List<Image>();
    [SerializeField]
    private Image spekko;
    [SerializeField]
    private Canvas plops;
    private GameObject dit;
    void Start () {

        lerder = gameObject.GetComponent<LineRenderer>();

        plers = new List<GameObject>();
         dit = Instantiate(blpel);
        dit.GetComponent<_Ballpool>().mxbl = ding; 
        // Use this for initialization

        backgrnd = Instantiate(backgrnd, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.farClipPlane)), new Quaternion(0,0,0,0));
        backgrnd.transform.localScale = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width*1.5f, Screen.height*1.5f));
        plops = GameObject.Find("Canvas").GetComponent<Canvas>();

        stagestart(plers,lpl);
	}
	
	// Update is called once per frame
	void Update () {

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            
            stagestart(plers,bloppo);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            bloppo++;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            bloppo--;
        }
        if (dit.GetComponent<_Ballpool>().boi() == true)
        {
            bloppo++;
            stagestart(plers, bloppo);
        }
    }
    
   

    void stagestart(List<GameObject> alplayers, int alpel)
    {
        if (alplayers.Count > 1) {
            float rotato = 360 / alplayers.Count;
            Vector2 middle = new Vector2(Screen.height / 2, Screen.width / 2);
            Debug.DrawRay(middle, new Vector3(0, 0, rotato));
        }
        /*
        if (alpel > 1)
        {
            
            for (int i =0; i<alpel; i++)
            {
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 360 / alpel * i);
                Debug.DrawRay(transform.position, transform.up, Color.red, 20);
                lerder.positionCount = alpel * 2;
                lerder.SetPosition(0 + 2*i, transform.up* Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.width,0)).y + transform.position);
                lerder.SetPosition(1 + 2*i, transform.position);
            }
            
          //  for(int i=0; i<;i++){}
            
        }*/
        

        
        if (sprets.Count < alpel)
        {
            while(sprets.Count < alpel)
            {
                sprets.Add(Instantiate(spekko, spekko.transform));
            }
        }else if(sprets.Count > alpel)
        {
            while(sprets.Count > alpel)
            {
                
                sprets.RemoveAt(0);
            }
        }else if(sprets.Count == alpel)
        {

        }



        while (sprets.Count != 0)
        {
            Destroy(sprets[0].gameObject);
            sprets.Remove(sprets[0]);
        }

        for (int i = alpel-1; i>=0; i--)
        {

            Image blop =
            Instantiate(spekko, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.farClipPlane)), new Quaternion(0, 0, 0, 0));
            blop.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.farClipPlane));
            blop.transform.localScale = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 1.5f, Screen.height * 1.5f));
            blop.fillAmount = blop.fillAmount / alpel * (i+1);
            blop.color = Random.ColorHSV();
            blop.transform.SetParent(plops.transform);
            sprets.Add(blop);
        }
        dit.GetComponent<_Ballpool>().unmakeall();
        for (int  i = alpel - 1; i >= 0; i--)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 360 / alpel * i -(360/alpel/2));
            dit.GetComponent<_Ballpool>().makestuff(new Color(sprets[i].color.r+0.1f, sprets[i].color.g + 0.1f, sprets[i].color.b + 0.1f), transform.up *2);
        }
        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 0);
    }

    void stageend()
    {
        
    }

    
}

public interface stages
{
    void begin();
    void during();
    void end();
}

public class stage1 : stages
{

    public void begin()
    {
        
    }

    public void during()
    {

    }

    public void end()
    {

    }
}

public class stage2 : stages
{

    public void begin()
    {

    }

    public void during()
    {

    }

    public void end()
    {

    }
}

public class stage3 : stages
{

    public void begin()
    {

    }

    public void during()
    {

    }

    public void end()
    {

    }
}
