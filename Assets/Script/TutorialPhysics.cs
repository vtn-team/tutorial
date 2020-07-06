using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPhysics : MonoBehaviour {

    public GameObject PointA;
    public GameObject PointB;

    enum ShotMode
    {
        None,
        ForceShot,
        AccelerationShot,
        ImpulseShot,
        VelocityChangeShot,

        BottomShot,
    };
    private ShotMode Mode = ShotMode.None;
    private bool GravityMode = false;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Mode = ShotMode.ForceShot;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Mode = ShotMode.AccelerationShot;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Mode = ShotMode.ImpulseShot;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Mode = ShotMode.VelocityChangeShot;
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Mode = ShotMode.BottomShot;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GravityMode = !GravityMode;
        }
        PointA.transform.Rotate(0, 1, 0);
    }

    private void FixedUpdate()
    {
        switch( Mode )
        {
            case ShotMode.ForceShot:
                {
                    Rigidbody rb = Shot();
                    rb.AddForce( PointA.transform.forward * 100, ForceMode.Force );
                }
                break;

            case ShotMode.AccelerationShot:
                {
                    Rigidbody rb = Shot();
                    rb.AddForce(PointA.transform.forward * 100, ForceMode.Acceleration);
                }
                break;

            case ShotMode.ImpulseShot:
                {
                    Rigidbody rb = Shot();
                    rb.AddForce(PointA.transform.forward * 5, ForceMode.Impulse);
                }
                break;

            case ShotMode.VelocityChangeShot:
                {
                    Rigidbody rb = Shot();
                    rb.AddForce(PointA.transform.forward * 5, ForceMode.VelocityChange);
                }
                break;

            case ShotMode.BottomShot:
                {
                    Rigidbody rb = BtShot();
                    rb.AddForce(PointB.transform.forward * 5, ForceMode.VelocityChange);
                }
                break;
        }
        if( Mode != ShotMode.None)
        {
            Mode = ShotMode.None;
        }
    }

    private Rigidbody Shot()
    {
        //オブジェクトの2m前に出現させるよ
        Vector3 offset = new Vector3(0,0,2);
        offset = PointA.transform.rotation * offset;
        //offset = PointA.transform.forward * 2.0f;
        GameObject shot = Instantiate((GameObject)Resources.Load("ShotPhysics"), PointA.transform.position + offset, PointA.transform.rotation);
        shot.transform.Rotate(90, 0, 0); //シリンダーをショットっぽく見せるためX90度曲げるよ
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        rb.useGravity = GravityMode;
        return rb;
    }

    private Rigidbody BtShot()
    {
        //Bの地点に出現させるよ
        GameObject shot = Instantiate((GameObject)Resources.Load("ShotPhysics"), PointB.transform.position, PointB.transform.rotation);
        shot.transform.Rotate(90, 0, 0); //シリンダーをショットっぽく見せるためX90度曲げるよ
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        rb.useGravity = GravityMode;
        return rb;
    }
}
