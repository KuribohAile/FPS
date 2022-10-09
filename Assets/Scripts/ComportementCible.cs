using UnityEngine;


public class ComportementCible : MonoBehaviour 
{
    [SerializeField] private GameObject BalleTiree;

    private static LayerMask cubeLayer;

    private void Awake() 
    {
        cubeLayer = LayerMask.NameToLayer("CubeCible");
    }
        
    private void OnCollisionEnter(Collision other)  
    {
        if (other.gameObject.layer == cubeLayer){
            Destroy(other.gameObject);
            Destroy(BalleTiree);
        }
    }
    
} 

