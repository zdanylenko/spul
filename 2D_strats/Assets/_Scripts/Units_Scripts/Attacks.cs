using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "attacks")]
public class Attacks : ScriptableObject {

    [SerializeField]
    private float cooldown; public float Cd { get { return (cooldown); } set { cooldown = value; } }
    [SerializeField]
    private float attacktime; public float Atime { get { return (attacktime); } set { attacktime = value; } }
    [SerializeField]
    private float windup; public float Wndup { get { return (windup); } set { windup = value; } }
    [SerializeField]
    private float recover; public float Recvr { get { return (recover); } set { recover = value; } }
    [SerializeField]
    private float attackdamage; public float At { get { return (attackdamage); } set { attackdamage = value; } }
    [SerializeField]
    private float attackrange; public float Rng { get { return (attackrange); } set { attackrange = value; } }
    [SerializeField]
    private bool rangedattack; public bool ren { get { return (rangedattack); } set { rangedattack = value; } }
    [SerializeField]
    private float rangedspeed; public float rnspd { get { return (rangedspeed); } set { rangedspeed = value; } }
    [SerializeField]
    private float attackpriority; public float pror { get { return (attackpriority); } set { attackpriority = value; } }
    [SerializeField]
    private int type; public int tp { get { return (type); } set { type = value; } }
   
   

}
