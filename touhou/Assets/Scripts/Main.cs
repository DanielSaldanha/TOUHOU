using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
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
    public float spin_speed;
    float time;

    //ALteraçoes
    

    public ParticleSystem system;
    void Awake()
    {
        
        Sumon();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
      
    }
    private void FixedUpdate()
    {

        time += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0,spin_speed * time);  
    }
    void Sumon()
    {
        angle = 360f / Number_of_coluns;
        for (int i = 0; i < Number_of_coluns; i++)
        {
            // A simple particle material with no texture.

           // Material particleMaterial = new Material(Shader.Find("Particles/Standard Unlit"));
             Material particleMaterial = material;

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
            mainModule.startSpeed = speed;

            mainModule.maxParticles = 10000;
           // mainModule.duration = 0f;
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            // var Colisao = system.trigger;
            //  Colisao.enter = ParticleSystemOverlapAction.Kill;
            var colisaum = system.collision;
            colisaum.enabled = true;                     //ativa ou desativa
            colisaum.type = ParticleSystemCollisionType.World;
            colisaum.mode = ParticleSystemCollisionMode.Collision2D;
            colisaum.bounce = 0;                          //nao deixar voar
            colisaum.collidesWith -= 6;  // -= 5                  //layer
            colisaum.sendCollisionMessages = true;        //identificar colisao
            go.layer += 8;

            var visualizar = system;
         //   visualizar.r



            var emission = system.emission;
            emission.enabled = false;
            
           var forma = system.shape;
           

           forma.shapeType = ParticleSystemShapeType.Sprite;
           forma.sprite = null;
            
           var text = system.textureSheetAnimation;
           text.mode = ParticleSystemAnimationMode.Sprites;
           text.AddSprite(texture);
           text.enabled = true;   
        }

        // Every 2 secs we will emit.
        InvokeRepeating("DoEmit", 0f, firerate);
    }

    void DoEmit()
    {
        foreach(Transform child in transform)
        {
            system = child.GetComponent<ParticleSystem>();
            // Any parameters we assign in emitParams will override the current system's when we call Emit.
            // Here we will override the start color and size.
            var emitparams = new ParticleSystem.EmitParams();
            emitparams.startColor = color;
            emitparams.startSize = size;
            emitparams.startLifetime = lifetime;

            system.Emit(emitparams, 10);
        }
    }
}
