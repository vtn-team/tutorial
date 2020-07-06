using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial3D : MonoBehaviour {
    public GameObject PointA;
    public GameObject PointB;

    private Quaternion PointAOrigRot;
    private Quaternion PointBOrigRot;
    private float Timer = 0.0f;

    // Use this for initialization
    void Start () {
        PointAOrigRot = PointA.transform.rotation;
        PointBOrigRot = PointB.transform.rotation;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //毎フレームやるのはちょっと無駄だけど元の状態に戻すよ
        PointA.transform.rotation = PointAOrigRot;
        PointB.transform.rotation = PointBOrigRot;

        //PointBを向くよ
        if ( Input.GetKey(KeyCode.Z))
        {
            PointA.transform.LookAt(PointB.transform);
        }

        //それぞれ45度向けるよ
        if (Input.GetKey(KeyCode.X))
        {
            PointA.transform.rotation = Quaternion.Euler(45,45,45);
        }

        //ゆっくり回転させるよ
        if (Input.GetKey(KeyCode.C))
        {
            Timer += Time.deltaTime; //経過時間をとる
            if( Timer > 5.0f)
            {
                Timer = 5.0f;
            }
            PointA.transform.rotation = Quaternion.Slerp(PointAOrigRot, Quaternion.Euler(45, 45, 45), Timer / 5.0f );
        }
        else
        {
            Timer = 0.0f;
        }

        //PointAが向いている方向に直進する弾が出るよ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject shot = Instantiate((GameObject)Resources.Load("Shot"), PointA.transform.position, PointA.transform.rotation);
            shot.transform.Rotate(90,0,0); //シリンダーをショットっぽく見せるためX90度曲げるよ

            Shot script = shot.GetComponent<Shot>();
            script.Power = PointA.transform.forward;
        }
    }

    private void FixedUpdate()
    {
    }
}
