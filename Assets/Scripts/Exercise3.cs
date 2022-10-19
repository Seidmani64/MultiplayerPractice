using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise3 : MonoBehaviour
{
    GameObject sun, mer;
    Vector3[] vSun, vMer;
    float rotZ;

    // Start is called before the first frame update
    void Start()
    {
        rotZ = 0;
        sun = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mer = GameObject.CreatePrimitive(PrimitiveType.Cube);
        vSun = sun.GetComponent<MeshFilter>().mesh.vertices;
        sun.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
        vMer = mer.GetComponent<MeshFilter>().mesh.vertices;
        mer.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        rotZ += 0.1f;
        Matrix4x4 c1Pos = Transformations.Translate(1.84f, 1.659f, 0);
        Matrix4x4 c2Pos = Transformations.Translate(3.83f, 1.659f, 0);
        sun.GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(c1Pos, vSun);
        
        Matrix4x4 tminusP = Transformations.Translate(-1.84f, -1.659f, 0);
        Matrix4x4 rotateZ = Transformations.RotateZ(rotZ);
        Matrix4x4 tplusP = c1Pos;

        Matrix4x4 rotatePivot =  tplusP * rotateZ * tminusP * c2Pos;
        mer.GetComponent<MeshFilter>().mesh.vertices = Transformations.Transform(rotatePivot, vMer);
    }
}
