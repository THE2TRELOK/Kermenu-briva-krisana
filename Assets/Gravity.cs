using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FreeFallSimulation : MonoBehaviour
{
    private float gravity = 9.81f; // Brīvā kritiena paātrinājums
    private float fallHeight;
    private Vector3 initialPosition;
    private float initialTime;
    private float velocity;
    private float distance;
    private bool Falling = false;
    private float lastVelocity; // Atrums
    private float fall;
    private float lastDistance;
    private Rigidbody rb; 
    private Collider collider; 
    private string massInput = "1"; 
    private string fallHeightInput = "0";
    private float fallTime;
    private void Start()
    {
        initialPosition = new Vector3(25f, 1.30f, 13f);
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        rb.isKinematic = true; //Freeze

        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        // Phys
        PhysicMaterial material = new PhysicMaterial();
        material.frictionCombine = PhysicMaterialCombine.Minimum;
        material.staticFriction = 0f;
        material.dynamicFriction = 0f;
        material.bounciness = 0f;
        collider.material = material;
    }

    private void Update()
    {
        if (Falling)
        {
            // Laiks
            float elapsedTime = Time.time - initialTime;

            // Atrums
            velocity = Mathf.Sqrt(2 * gravity * fallHeight);

            //  Laiks
            fallTime = Time.time - initialTime;

            // Attalums S = 1/2 * g * t^2
            distance = 0.5f * gravity * elapsedTime * elapsedTime;

            float newYPosition = initialPosition.y + fallHeight - Mathf.Abs(distance);
            Vector3 newPosition = new Vector3(initialPosition.x, newYPosition, initialPosition.z);

            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Objekta apstasana pec sadursmes
        Falling = false;
        rb.isKinematic = true;

            fall = Time.time - initialTime;


        // Atrums
        lastVelocity = velocity;
        lastDistance = distance;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Svars (KG):");
        massInput = GUI.TextField(new Rect(10, 30, 100, 20), massInput);

        GUI.Label(new Rect(10, 60, 200, 20), "Krituma augstums (M):");
        fallHeightInput = GUI.TextField(new Rect(10, 80, 100, 20), fallHeightInput);

        if (!Falling && GUI.Button(new Rect(10, 110, 100, 30), "Sakt kustibu"))
        {
            // objekta krisana
            initialTime = Time.time;
            Falling = true;

            // Atļaut objektam pārvietoties
            rb.isKinematic = false;

            // Tastatūras dati (lietotajs)
            fallHeight = float.Parse(fallHeightInput);
        }

        if (Falling)
        {
            GUI.Label(new Rect(10, 150, 200, 20), "Atrums: " + velocity.ToString("F2") + "M/S");
            GUI.Label(new Rect(10, 170, 200, 20), "Attalums: " + distance.ToString("F2") + " M");
            GUI.Label(new Rect(10, 190, 200, 20), "Laiks: " + fallTime.ToString("F2") + " S");
        }
        else
        {
            // Pedejais atrums
            GUI.Label(new Rect(10, 150, 250, 20), "Atrums: " + lastVelocity.ToString("F2") + " M/S");
            GUI.Label(new Rect(10, 190, 250, 20), "Laiks: " + fall.ToString("F2") + " S");
        }

        if (GUI.Button(new Rect(Screen.width - 200, 10, 170, 30), "Atgriezties pie izvēlnes"))
        {
            play0();
        }
    }
    
    public void play0()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
