using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise2 : MonoBehaviour
{
    GameObject sun, mer, ven, ear, mon;
    Vector3[] vSun, vMer, vVen, vEar, vMon;
    float rotY;

    // Start is called before the first frame update
    void Start()
    {
        rotY = 0;
        sun = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ven = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ear = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mon = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        vSun = sun.GetComponent<MeshFilter>().mesh.vertices;
        sun.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
        vMer = mer.GetComponent<MeshFilter>().mesh.vertices;
        mer.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        vVen = ven.GetComponent<MeshFilter>().mesh.vertices;
        Color venCol = new Color(1f, 0.77f, 0.289f, 1);
        ven.GetComponent<MeshRenderer>().material.SetColor("_Color", venCol);
        vEar = ear.GetComponent<MeshFilter>().mesh.vertices;
        ear.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
        vMon = mon.GetComponent<MeshFilter>().mesh.vertices;
        mon.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.gray);
    }

    void Update()
    {
        rotY += 0.1f;
        Matrix4x4 tr = Transformations.RotateY(rotY);
        sun.GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(tr, vSun);
        sun.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        Matrix4x4 tm = Transformations.Translate(2.0f, 0, 0);
        Matrix4x4 ts = Transformations.Scale(0.15f, 0.15f, 0.15f);
        tr = Transformations.RotateY(rotY * 1.1f);
        mer.GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(tr*tm*ts, vMer);
        mer.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        tm = Transformations.Translate(3.0f, 0, 0);
        ts = Transformations.Scale(0.25f, 0.25f, 0.25f);
        tr = Transformations.RotateY(rotY * 0.7f);
        ven.GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(tr*tm*ts, vVen);
        ven.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        tm = Transformations.Translate(4.0f, 0, 0);
        ts = Transformations.Scale(0.35f, 0.35f, 0.35f);
        tr = Transformations.RotateY(rotY * 1.3f);
        ear.GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(tr*tm*ts, vEar);
        ear.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        Matrix4x4 tm2 = Transformations.Translate(0.5f, 0, 0);
        ts = Transformations.Scale(0.1f, 0.1f, 0.1f);
        Matrix4x4 tr2 = Transformations.RotateY(rotY * 1.1f);
        mon.GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(tr*tm*tr2*tm2*ts, vMon);
        mon.GetComponent<MeshFilter>().mesh.RecalculateNormals();

        
    }

}
