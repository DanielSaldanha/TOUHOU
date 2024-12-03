using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main2 : MonoBehaviour
{
    public int Number_of_coluns;
    public float speed;
    public Sprite texture;
    public Color color;
    public float lifetime;
    public float firerate;
    public float size;
    float angle;
    public Material material;

    public ParticleSystem system;
    void Awake()
    {
        apareca();
    }
    void apareca()
    {
        angle = 180f / Number_of_coluns;
        for (int i = 0; i < Number_of_coluns; i++)
        {
            // A simple particle material with no texture.

            Material particleMaterial = new Material(Shader.Find("Particles/Standard Unlit"));
           // Material particleMaterial = material;

            // Create a green Particle System.
            var go = new GameObject("Particle System");
            go.transform.Rotate(angle * i, 90, 0); // Rotate so the system emits upwards.
            go.transform.parent = this.transform;
            go.transform.position = this.transform.position;
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            var mainModule = system.main;
            mainModule.startColor = Color.green;
            mainModule.startSize = 0.5f;
           // mainModule.startSpeed = speed;
           

            var emission = system.emission;
            emission.enabled = false;

            var forma = system.shape;
            forma.enabled = true;
            forma.shapeType = ParticleSystemShapeType.Sprite;
            forma.sprite = null;
        }
        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 2.0f, 2.0f);
    }

    void DoEmit()
    {             
        foreach (Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitParams = new ParticleSystem.EmitParams();
         emitParams.startColor = Color.red;
         emitParams.startSize = 0.2f;
         system.Emit(emitParams, 10);
       //  system.Play(); // Continue normal emissions
        }
        
    }
}
