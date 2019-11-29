using UnityEngine;
using Unity.Entities;
using System.Collections.Generic;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Collections;
using Unity.Mathematics;

namespace RotateCube
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private int cubesToSpawn;
        [SerializeField] private float degreesPerSecondMin, degreesPerSecondMax, xMin, xMax, yMin, yMax, zMin, zMax;
        [SerializeField] private Mesh cubeMesh;
        [SerializeField] private Material cubeMaterial;

        EntityManager entityManager;

        private void Start()
        {
            entityManager = World.Active.EntityManager;

            EntityArchetype cubeArchetype = entityManager.CreateArchetype(
                typeof(Rotate),
                typeof(Translation),
                typeof(Rotation),
                typeof(RenderMesh),
                typeof(LocalToWorld)
            );

            NativeArray<Entity> cubeArray = new NativeArray<Entity>(cubesToSpawn, Allocator.Temp);
            entityManager.CreateEntity(cubeArchetype, cubeArray);

            foreach(Entity entity in cubeArray)
            {
                entityManager.SetComponentData(
                    entity, 
                    new Rotate() 
                    {
                        radiansPerSecond = math.radians(UnityEngine.Random.Range(degreesPerSecondMin, degreesPerSecondMax))
                    }
                );
                
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
                    new Translation()
                    {
                        Value = new float3() 
                        {
                            x = UnityEngine.Random.Range(xMin, xMax),
                            y = UnityEngine.Random.Range(yMin, yMax),
                            z = UnityEngine.Random.Range(zMin, zMax)
                            
                        }
                    }
                );
            }

            cubeArray.Dispose();
        }

    }
}