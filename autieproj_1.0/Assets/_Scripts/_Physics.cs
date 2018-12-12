using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Physics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private List<int> allhits = new List<int>();
        void Update()
        {
        
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    if (Physics.Raycast(ray, out hit, 1000f))
                    {
                        Debug.Log("Touch enter on " + hit.collider.name);
                    }
                }
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                  RaycastHit hit;
                  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {               
                  mashslices(hit.triangleIndex);
                }
            }
        
        }
      
    private void mashslices(int indexer)
    {
        Destroy(this.gameObject.GetComponent<MeshCollider>());
        Mesh mesje = transform.GetComponent<MeshFilter>().mesh;
        
        int[] posttrings = mesje.triangles;
        int[] preftrings = new int[mesje.triangles.Length - 3];

        int i = 0;
        int j = 0;
        while (j < mesje.triangles.Length)
        {
            if (j != indexer*3)
            {
                preftrings[i++] = posttrings[j++];
                preftrings[i++] = posttrings[j++];
                preftrings[i++] = posttrings[j++];
            }
            else
            {
                j += 3;
            }
        }
        transform.GetComponent<MeshFilter>().mesh.triangles = preftrings;
        this.gameObject.AddComponent<MeshCollider>();
    }
    
}
