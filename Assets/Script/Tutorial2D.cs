using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial2D : MonoBehaviour {

    public Image PointA;
    public Image PointB;
    public Text ResultText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(PointA && PointB && ResultText)
        {
            Vector3 vec = PointB.transform.position - PointA.transform.position;
            float radian = Mathf.Atan2(vec.y, vec.x);
            //float length = Vector3.Distance(PointA.transform.position, PointB.transform.position);
            float length = Mathf.Sqrt((vec.x * vec.x) + (vec.y * vec.y));
            ResultText.text = "AとBの間の角度は" + (radian * 180 / Mathf.PI) + "度\n 距離は" + length + "";
        }
	}
}
