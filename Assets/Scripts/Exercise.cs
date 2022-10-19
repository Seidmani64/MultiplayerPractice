using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Point A 1,2,3
Point B rotate 30 deg around X axis, then translate 3 units down
Point C same as b but translation before rotation

*/


public class Exercise : MonoBehaviour
{
    Vector4 a,b,c,d,e,f,g,h;
    Vector4 a2,b2,c2,d2,e2,f2,g2,h2;
    // Start is called before the first frame update
    void Start()
    {
        a = new Vector4((float)-1.75,(float)-1.75,(float)-1.75,1);
        b = new Vector4((float)1.75,(float)-1.75,(float)-1.75,1);
        c = new Vector4((float)-1.75,(float)1.75,(float)-1.75,1);
        d = new Vector4((float)1.75,(float)1.75,(float)-1.75,1);
        e = new Vector4((float)-1.75,(float)-1.75,(float)1.75,1);
        f = new Vector4((float)1.75,(float)-1.75,(float)1.75,1);
        g = new Vector4((float)-1.75,(float)1.75,(float)1.75,1);
        h = new Vector4((float)1.75,(float)1.75,(float)1.75,1);
        Matrix4x4 r1 = Transformations.RotateZ((float)-15.63);
        Matrix4x4 t = Transformations.Translate(0, 0, (float)12.77);
        Matrix4x4 r2 = Transformations.RotateY((float)2.48);

        a2 = r1 * t * r2 * a;
        b2 = r1 * t * r2 * b;
        c2 = r1 * t * r2 * c;
        d2 = r1 * t * r2 * d;
        e2 = r1 * t * r2 * e;
        f2 = r1 * t * r2 * f;
        g2 = r1 * t * r2 * g;
        h2 = r1 * t * r2 * h;


        Debug.Log(a2);
        Debug.Log(b2);
        Debug.Log(c2);
        Debug.Log(d2);
        Debug.Log(e2);
        Debug.Log(f2);
        Debug.Log(g2);
        Debug.Log(h2);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(a,b,Color.white);
        Debug.DrawLine(a,c,Color.white);
        Debug.DrawLine(a,e,Color.white);
        Debug.DrawLine(b,d,Color.white);
        Debug.DrawLine(b,f,Color.white);
        Debug.DrawLine(d,c,Color.white);
        Debug.DrawLine(d,h,Color.white);
        Debug.DrawLine(c,g,Color.white);
        Debug.DrawLine(a,e,Color.white);
        Debug.DrawLine(e,f,Color.white);
        Debug.DrawLine(e,g,Color.white);
        Debug.DrawLine(a,e,Color.white);
        Debug.DrawLine(h,f,Color.white);
        Debug.DrawLine(h,g,Color.white);

        Debug.DrawLine(a2,b2,Color.red);
        Debug.DrawLine(a2,c2,Color.red);
        Debug.DrawLine(a2,e2,Color.red);
        Debug.DrawLine(b2,d2,Color.red);
        Debug.DrawLine(b2,f2,Color.red);
        Debug.DrawLine(d2,c2,Color.red);
        Debug.DrawLine(d2,h2,Color.red);
        Debug.DrawLine(c2,g2,Color.red);
        Debug.DrawLine(a2,e2,Color.red);
        Debug.DrawLine(e2,f2,Color.red);
        Debug.DrawLine(e2,g2,Color.red);
        Debug.DrawLine(a2,e2,Color.red);
        Debug.DrawLine(h2,f2,Color.red);
        Debug.DrawLine(h2,g2,Color.red);
    }
}
