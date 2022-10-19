using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
public Vector3 ka;
    public Vector3 kd;
    public Vector3 ks;
    public Vector3 Ia;
    public Vector3 Id;
    public Vector3 Is;
    public float alpha;
    public Vector3 PoI;
    public Vector3 n;
    public Vector3 LIGHT;
    public Vector3 CAMERA;
    public Vector3 SC;
    public float SR;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 i = Illumination();
        Debug.Log(i.ToString("F5"));


        GameObject sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sph.transform.position = SC;
        sph.transform.localScale = new Vector3(SR*2f,SR*2f,SR*2f);
        Renderer rend = sph.GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Specular");
        rend.material.SetColor("_Color", new Color(kd.x, kd.y,kd.z));
        rend.material.SetColor("_SpecColor", new Color(ks.x,ks.y,ks.z));

        GameObject pointLight = new GameObject("ThePointLight");
        Light lightComp = pointLight.AddComponent<Light>();
        lightComp.type = LightType.Point;
        pointLight.transform.position = LIGHT;
        lightComp.color = new Color(Id.x,Id.y,Id.z);
        lightComp.intensity = 20;

        GameObject smallSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        smallSphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        smallSphere.transform.position = FindTopLeftFrustumNear();
        Renderer rend2 = smallSphere.GetComponent<Renderer>();
        rend2.material.shader = Shader.Find("Specular");
        rend2.material.SetColor("_Color", new Color(1, 0, 0));
        rend2.material.SetColor("_SpecColor", new Color(1, 1, 1));
        

        Camera.main.transform.position = CAMERA;
        Camera.main.transform.LookAt(PoI);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 c = Camera.main.transform.position;
        /*
        Vector3 l = LIGHT - PoI;
        Vector3 lp = n * Vector3.Dot(n.normalized,l);
        Vector3 lo = l - lp;
        Vector3 r = lp-lo;
        Vector3 v = CAMERA - PoI;

        Debug.DrawLine(PoI,PoI + l , Color.red);
        Debug.DrawLine(PoI,PoI + r , Color.magenta);
        Debug.DrawLine(PoI,PoI + n, Color.green);
        Debug.DrawLine(PoI,PoI + v, Color.blue);
        */
    }

    Vector3 FindTopLeftFrustumNear()
    {
        Camera cam = Camera.main;
        Vector3 o = cam.transform.position;
        Vector3 p = o + cam.transform.forward * cam.nearClipPlane;
        float frustumHeight = 2.0f * cam.nearClipPlane * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustumWidth = frustumHeight * cam.aspect;
        p += cam.transform.up * frustumHeight / 2.0f;
        p -= cam.transform.right * frustumWidth / 2.0f;
        return p;
    }

    Vector3 Illumination()
    {
        Vector3 A = new Vector3(ka.x * Ia.x, ka.y * Ia.y, ka.z * Ia.z);
        Vector3 D = new Vector3(kd.x * Id.x, kd.y * Id.y, kd.z * Id.z);
        Vector3 S = new Vector3(ks.x * Is.x, ks.y * Is.y, ks.z * Is.z);

        Vector3 l = LIGHT - PoI;
        Vector3 v = CAMERA - PoI;
        float dotNuLu = Vector3.Dot(n.normalized, l.normalized);
        float dotNuL = Vector3.Dot(n.normalized, l);
        Vector3 lp = n*dotNuL;
        Vector3 lo = l - lp;
        Vector3 r = lp - lo;
        D *= dotNuLu;
        S *= Mathf.Pow(Vector3.Dot(v.normalized,r.normalized), alpha);
        return A + D + S;
    }

    Vector3 Cast()
    {
        Camera cam = Camera.main;
        float frustumHeight = 2.0f * cam.nearClipPlane * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustumWidth = frustumHeight * cam.aspect;
        float pixelWidth = frustumWidth / 480f; Debug.Log(pixelWidth.ToString("F5"));
        float pixelHeight = frustumHeight / 640f; Debug.Log(pixelHeight.ToString("F5"));
        Vector3 center = FindTopLeftFrustumNear();
        center += (pixelWidth / 2f) * cam.transform.right;
        center -= (pixelHeight / 2f) * cam.transform.up;
        return center;
    }
}


