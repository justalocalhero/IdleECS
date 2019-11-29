using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Collections;

namespace IdleECS
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private int cubesToSpawn;
        [SerializeField] private float velocity, lifetime, xMin, xMax, yMin, yMax, zMin, zMax, scale;
        [SerializeField] private Mesh cubeMesh;
        [SerializeField] private Material cubeMaterial;

        EntityManager entityManager;
        EntityArchetype cubeArchetype;

        private void Start()
        {
            entityManager = World.Active.EntityManager;

            cubeArchetype = entityManager.CreateArchetype(
                typeof(Lifetime),
                typeof(Translation),
                typeof(RenderMesh),
                typeof(LocalToWorld),
                typeof(Velocity),
                typeof(Scale)
            );
        }

        private void Update()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                NativeArray<Entity> cubeArray = new NativeArray<Entity>(cubesToSpawn, Allocator.Temp);
                entityManager.CreateEntity(cubeArchetype, cubeArray);

                foreach(Entity entity in cubeArray)
                {
                    
                    entityManager.SetSharedComponentData(
                        entity, 
                        new RenderMesh() 
                        {
                            mesh = cubeMesh,
                            material = cubeMaterial
                        }
                    );
                    
                    entityManager.SetComponentData(
                        entity, 
                        new Lifetime
                        {
                            value = lifetime
                        }
                    );                 

                    entityManager.SetComponentData(
                        entity,
                        new Scale()
                        {
                            Value = scale
                        }
                    );

                    entityManager.SetComponentData(
                        entity,
                        new Translation()
                        {
                            Value = new float3{
                                x = transform.position.x + UnityEngine.Random.Range(xMin, xMax),
                                y = transform.position.y + UnityEngine.Random.Range(yMin, yMax),
                                z = transform.position.z + UnityEngine.Random.Range(zMin, zMax),
                            }
                        }
                    );   

                    entityManager.SetComponentData(
                        entity,
                        new Velocity()
                        {
                            value = new float3 {y = velocity}
                        }
                    );
                }

                cubeArray.Dispose();

            }
        }
    }
}