using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public Vector3 Power;
    public float Life = 1.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Power;
        Life -= Time.deltaTime;

        if(Life < 0.0 )
        {
            Destroy(this.gameObject);
        }
    }
}
