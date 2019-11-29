using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;
using Unity.Collections;

namespace IdleECS
{
    public class EnemySpawner : MonoBehaviour
    {
        private EntityManager entityManager;
        private EntityArchetype enemyArchetype;
        [SerializeField] private float velocityXMin, velocityXMax, velocityYMin, velocityYMax, 
            lifetime, 
            positionXMin, positionXMax, positionYMin, positionYMax;
        [SerializeField] private int spawnCount;
        [SerializeField] private Mesh enemyMesh;
        [SerializeField] private Material enemyMaterial;
        
        Unity.Mathematics.Random random;


        void Start()
        { 
            
            entityManager = World.Active.EntityManager;
            random = new Unity.Mathematics.Random((uint)UnityEngine.Random.Range(0, int.MaxValue));

            enemyArchetype = entityManager.CreateArchetype(
                typeof(Enemy),
                typeof(Velocity),
                typeof(Translation),
                typeof(Rotation),
                typeof(RenderMesh),
                typeof(LocalToWorld),
                typeof(Lifetime)
            );
        }

        void Update()
        {
            NativeArray<Entity> enemyEntities = new NativeArray<Entity>(spawnCount, Allocator.Temp);

            entityManager.CreateEntity(enemyArchetype, enemyEntities);

            foreach(Entity enemyEntity in enemyEntities)
            {
                entityManager.SetSharedComponentData(
                    enemyEntity, 
                    new RenderMesh() 
                    {
                        mesh = enemyMesh,
                        material = enemyMaterial
                    }
                );

                entityManager.SetComponentData(
                    enemyEntity,
                    new Translation()
                    {
                        Value = new float3
                        {
                            x = transform.position.x + random.NextFloat(positionXMin, positionXMax),
                            y = transform.position.y + random.NextFloat(positionYMin, positionYMax),
                            z = transform.position.z                        
                        }
                    }
                );

                entityManager.SetComponentData(
                    enemyEntity,
                    new Lifetime()
                    {
                        value = lifetime
                    }
                );

                entityManager.SetComponentData(
                    enemyEntity,
                    new Velocity()
                    {
                        value = new float3
                        {
                            x = random.NextFloat(velocityXMin, velocityXMax),
                            y = random.NextFloat(velocityYMin, velocityYMax)
                        }
                    }
                );
            }

            enemyEntities.Dispose();
        }
    }
}