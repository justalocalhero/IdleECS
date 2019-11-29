using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;

namespace IdleECS
{
    public class MovementTest : MonoBehaviour
    {
        private EntityManager entityManager;
        private Entity testEntity;
        [SerializeField] private float velocityMag;
        [SerializeField] private Mesh cubeMesh;
        [SerializeField] private Material cubeMaterial;


        void Start()
        { 
            entityManager = World.Active.EntityManager;

            EntityArchetype cubeArchetype = entityManager.CreateArchetype(
                typeof(Velocity),
                typeof(Translation),
                typeof(Rotation),
                typeof(RenderMesh),
                typeof(LocalToWorld)
            );

            testEntity = entityManager.CreateEntity(cubeArchetype); 
            
            entityManager.SetSharedComponentData(
                testEntity, 
                new RenderMesh() 
                {
                    mesh = cubeMesh,
                    material = cubeMaterial
                }
            );

            entityManager.SetComponentData(
                testEntity,
                new Translation()
                {
                    Value = transform.position
                }
            );
        }

        void Update()
        {
            if(Input.GetKey(KeyCode.A))
            {            
                entityManager.SetComponentData(testEntity, new Velocity{
                    value =  new float3 {x = -velocityMag}
                });
            }

            else if(Input.GetKey(KeyCode.D))
            {
                entityManager.SetComponentData(testEntity, new Velocity{
                    value =  new float3 {x = velocityMag}
                });
            }

            else
            {
                entityManager.SetComponentData(testEntity, new Velocity{
                    value =  new float3 {y = 0}
                });                
            }

        }
    }
}