using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "units")]
public class Units : ScriptableObject
{

    [SerializeField]
    private float hp; public float Hp { get { return (hp); } set { hp = value; } }
    [SerializeField]
    private float movespeed; public float Ms { get { return (movespeed); } set { movespeed = value; } }
    [SerializeField]
    private float team; public float Tm { get { return (team); } set { team = value; } }
    [SerializeField]
    private string detag; public string tg { get { return (detag); } set { detag = value;  } }
    [SerializeField]
    private int Leyerbee; public int Lei { get { return (Leyerbee); } set { Leyerbee = value; } }
    [SerializeField]
    private LayerMask Leyersee; public LayerMask Ley { get { return (Leyersee); } set { Leyersee = value; } }
    [SerializeField]
    private List<float> resist; public List<float>  res { get { return (resist); } set { resist = value; } }
    [SerializeField]
    private float cost; public float cs { get { return (cost); }  set { cost = value; } }
    [SerializeField]
    private string job; public string jb { get { return (job); } set { job = value; } }
    [SerializeField]
    private float minercarryload; public float minemax { get { return (minercarryload); } set { minercarryload = value; } }
    [SerializeField]
    private float minerhitpayload; public float minehit { get { return (minerhitpayload); } set { minerhitpayload = value; } }
    [SerializeField]
    private float maxminecooldown; public float mxcl { get { return (maxminecooldown); } set { maxminecooldown = value; } }
    [SerializeField]
    private float maxbuycooldown; public float buycl { get { return (maxbuycooldown); } set { maxbuycooldown = value; } }

}
    
