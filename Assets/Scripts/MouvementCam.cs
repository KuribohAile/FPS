using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class MouvementCam : MonoBehaviour

{
    
    public float vitesseCam = 5.0f;
    public Camera CamJoueur;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private Vector2 rotation = Vector2.zero;

    [SerializeField] private GameObject Balle;
    [SerializeField] private Transform cameraTransform;
    

    [HideInInspector]
    public bool canMove = true;

    private void SpawnBalle()
    {
        GameObject balle = Instantiate(Balle,cameraTransform.position + cameraTransform.forward * 1, Quaternion.identity);

        Rigidbody balleRigidbody = balle.GetComponent<Rigidbody>();  //on recupere son rigide body

        balleRigidbody.AddForce(cameraTransform.forward * 1000); //on applique une impulsion
    }




    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; //appuyer sur echap pour revoir la souris (elle disparait quand on clique sur le "game")
    }

    



    void Update()
    {
        
            Vector3 forward = transform.TransformDirection(Vector3.forward);  //Les deplacements se font avec les fleches directionnelles
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? vitesseCam * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? vitesseCam * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        

        characterController.Move(moveDirection * Time.deltaTime);

        
        if (canMove) //rotation camera et joueur
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            CamJoueur.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }

        if(Input.GetButtonDown("Fire1"))
        {
            SpawnBalle();
        }
    }
}