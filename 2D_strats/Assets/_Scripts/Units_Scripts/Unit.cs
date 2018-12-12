using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    [SerializeField]
    private bool house = false; public bool hs { get { return (house); } set { house = value; } }

    [SerializeField]
    private Units stats; public Units stts { get { return (stats); } set { stats = value; } }
    private float currentmoney; public float curmon { get { return (currentmoney); } set { currentmoney = value; } }  
    private float minecooldown; public float mincl { get { return (minecooldown); } set { minecooldown = value; } }   
    private Mine wrek;
    private List<Statemachine> stet = new List<Statemachine>();
    [SerializeField]
    private int currentstate = 1; public int curstt { get { return (currentstate); } set { currentstate = value; } }
    private float hp; public float health { get { return (hp); } set { hp = value; } }
    private Dead ded; private Walking wlk; private Attacking atk; private Mining mng;
    private List<Attack> attaks = new List<Attack>(); public List<Attack> ateks { get { return (attaks); } set { attaks = value; } }
    private List<Attack> options = new List<Attack>(); private List<int> spots = new List<int>();
    private float minecool;
    
    void Start() {
        ded = new Dead(this); wlk = new Walking(this); atk = new Attacking(this); mng = new Mining(this);
        hp = stats.Hp;
        stet.Add(ded); stet.Add(wlk); stet.Add(atk); stet.Add(mng);
        gameObject.tag = stats.tg;
        gameObject.layer = stats.Lei;     
    }

    void Update() {
        if (house != true)
        {
            statecheck();
            if (minecool < stts.mxcl)
            {
                minecool += Time.deltaTime;
            }
        }
        else
        {
            if (stts.Hp <= 0)
            {
                
            }
        }
    }
    private void statecheck()
    {
        stet[currentstate].During();
    }
    public void stateswitch(int next)
    {
        stet[currentstate].End();
        stet[next].Begin();
        currentstate = next;
    }
    public void Unmake()
    {
        Destroy(gameObject);
    }
    public void move(float direnzo)
    {
        if (direnzo == 0) {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + stats.Ms, transform.position.y, transform.position.z), 0.22222f);
        }
        else {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - stats.Ms, transform.position.y, transform.position.z), 0.22222f);
        }
    }
    public void damage(int typ, float damg)
    {
        hp -= damg * stats.res[typ];
    }
    public void choose() {        
            options.Clear();
            spots.Clear();
            for (int i = 0; i < attaks.Count; i++)
            {
                if (attaks[i].attackcheck(stats.Tm) && attaks[i].cell <=0)
                {
                    options.Add(attaks[i]);
                }
            }
            
            float pref = -1;
            for (int i = 0; i < options.Count; i++)
            {
                if (pref < options[i].attk.pror)
                {
                    spots.Clear();
                    pref = options[i].attk.pror;
                    spots.Add(i);
                }
                if (pref == options[i].attk.pror)
                {
                    spots.Add(i);
                }
            }
            while (spots.Count > 1)
            {
                spots.RemoveAt(Random.Range(0, spots.Count));
            }
            if (options.Count > 0)
            {
                options[spots[0]].attacknow(stats.Tm);               
            }
           
        
    }
    
    public void cashin()
    {
        
        Vector2 walk;
        if (stats.Tm == 1)
        {
            walk = Vector2.right;
        }
        else
        {
            walk = Vector2.left;
        }

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + gameObject.GetComponent<Renderer>().bounds.size.x * walk.x / 2, transform.position.y), walk, 5, 1 << 11);
      
        if(hit && hit.collider.tag == "house")
        {
            hit.collider.GetComponentInParent<House>().munnie += currentmoney;
            currentmoney = 0;
        }
    }

    public bool mine()
    {
        Vector2 walk;
        if (stats.Tm == 0)
        {
            walk = Vector2.right;
        }
        else
        {
            walk = Vector2.left;
        }
        
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), walk, 5, 1 << 10);
        
        if (hit && hit.collider.GetComponent<Mine>().wrk.Count < hit.collider.GetComponent<Mine>().wrok)
        {
            wrek = hit.collider.GetComponent<Mine>();
            return (true);
        }else if (hit && hit.collider.GetComponent<Mine>().wrk.Contains(this))
        {
            return (true);
        }
        else
        {
            
            return (false);
        }
    }
    public void mineforreal(int ting)
    {
        Vector2 walk;
        if (stats.Tm == 0)
        {
            walk = Vector2.right;
        }
        else
        {
            walk = Vector2.left;
        }
        
        if (wrek != null)
        {
            if (ting == 0)
            {               
                    wrek.wrk.Add(this);                
            }else if(ting == 1)
            {
                wrek.wrk.Remove(this);
                wrek = null;
            }else if(ting == 2)
            {
                if (minecool >= stts.mxcl)
                {
                    minecool = 0;
                    currentmoney += wrek.glod * stats.minehit;
                }
            }
        }
    }

}
public interface Statemachine
{
        void Begin();
        void During();
        void End();
}
public class Dead  : Statemachine
{
    private Unit _Me;
    private float deathtimer = 0;
    private float expirationdate = 0;
    public Dead(Unit me)
    {
        _Me = me;
    }
    public void Begin()
    {
        deathtimer = 0;
        _Me.gameObject.layer = 2;
        
    }
    public void During()
    {
       if (_Me.health > 0)
       {
            _Me.stateswitch(1);
       } 
       deathtimer += Time.deltaTime;
        if(deathtimer>= expirationdate){
            _Me.Unmake();
        }
    }
    public void End()
    {
        deathtimer = 0;
        _Me.gameObject.layer = _Me.stts.Lei;
    }
}
public class Walking : Statemachine
{
    private Unit _Me;  
    public Walking(Unit me)
    {
        _Me = me;
        
    }
    public void Begin()
    {

    }
    public void During()
    {
        
        if (_Me.health <= 0)
        {
            _Me.stateswitch(0);
        }
        
            if (_Me.ateks[0].attackcheck(_Me.stts.Tm))
            {
                _Me.stateswitch(2);
            }
                
        if(_Me.curstt == 1)
        {
            if (_Me.stts.jb == "Miner")
            {
                
                if (_Me.curmon >= _Me.stts.minemax)
                {
                    _Me.cashin();
                    if (_Me.stts.Tm == 0)
                    {
                        _Me.move(1);
                    }else if(_Me.stts.Tm == 1)
                    {
                        _Me.move(0);
                    }



                }else if (_Me.mine())
                {
                    _Me.stateswitch(3);
                }
                else
                {
                    _Me.move(_Me.stts.Tm);                  
                }
            }
            else
            {
                _Me.move(_Me.stts.Tm);
            }
        }
    }
    public void End()
    {

    }
}
public class Attacking : Statemachine
{
    private Unit _Me;
    public Attacking(Unit me)
    {
        _Me = me;
    }
    public void Begin()
    {

    }
    public void During()
    {
        if (_Me.health <= 0)
        {
            _Me.stateswitch(0);
        }
        
            if (_Me.ateks[0].attackcheck(_Me.stts.Tm) != true)
            {
                _Me.stateswitch(1);
            }
        
        if (_Me.curstt == 2)
        {
            _Me.choose();
        }
    }
    public void End()
    {

    }
}
public class Mining : Statemachine
{
    private Unit _Me;
    public Mining(Unit me)
    {
        _Me = me;

    }
    public void Begin()
    {
        _Me.mineforreal(0);
    }
    public void During()
    {
        if (_Me.health <= 0)
        {
            _Me.stateswitch(0);
        }
        if (_Me.ateks[0].attackcheck(_Me.stts.Tm))
        {
            _Me.stateswitch(2);
        }
        if (_Me.curstt == 3)
        {
            if (_Me.mine())
            {
                if(_Me.curmon >= _Me.stts.minemax)
                {
                    _Me.curmon = _Me.stts.minemax;
                    _Me.stateswitch(1);
                }
                else
                {
                    _Me.mineforreal(2);
                }
            }
            else
            {
                _Me.stateswitch(1);
            }
        }
        
    }
    public void End()
    {
        _Me.mineforreal(1);
    }
}
