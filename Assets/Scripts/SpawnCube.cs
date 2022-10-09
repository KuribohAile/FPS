using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public GameObject monCube;
    private int TamponNbCube;
    private float TamponRayCube;
    private float angle;
    private Vector3 TamponPosiCentre = new Vector3();
    List<GameObject> IteCube = new List<GameObject>(); //important
    private int nbCube;
    private float rayon;
    private Vector3 position = new Vector3();
     private float timeleft;

    void CubeInstance()
    {
        TamponPosiCentre = position;

        
        float rayon = Random.Range(7f,15f);
        float angle = Random.Range(-10f, -1f);
        float x = Mathf.Cos(angle) * rayon;
        float z = Mathf.Sin(angle) * rayon;
                
        Vector3 positionCube = transform.position + new Vector3(x, 5f, z);
        Quaternion rotationCube = Quaternion.Euler(0, angle, 0);
        var repCube = Instantiate(monCube, positionCube + position, rotationCube);
        IteCube.Add(repCube);


    }

    // Start is called before the first frame update
    void Start()
    {

        CubeInstance();

    }

    // Update is called once per frame
    void Update()
    {

            timeleft -= Time.deltaTime;
            if (timeleft<0){
                CubeInstance();
                timeleft= 0.5f ;
                } 
   
    }
}