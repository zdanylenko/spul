using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
    [SerializeField]
    private float goldperhit; public float glod { get { return (goldperhit); } set { goldperhit = value; } }
    [SerializeField]
    private float workerlimit; public float wrok { get { return (workerlimit); } set { workerlimit = value; } }
   

    private List<Unit> workers = new List<Unit>(); public List<Unit> wrk { get { return (workers); } set { workers = value; } }
    
}
