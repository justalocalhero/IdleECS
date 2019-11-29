using UnityEngine;
using Unity.Entities;

namespace IdleECS
{
    public class ExperienceAddTest : MonoBehaviour
    {
        [SerializeField] private float experienceToAdd;
        private EntityManager entityManager;
        private Entity adder;
        
        void Start()
        {
            entityManager = World.Active.EntityManager;

            EntityArchetype adderArchetype = entityManager.CreateArchetype(
                typeof(Experience),
                typeof(CurrencyAdder)
            );

            adder = entityManager.CreateEntity(adderArchetype);
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                entityManager.SetComponentData(adder, new CurrencyAdder{
                    toAdd = experienceToAdd
                });
            }
        }
    }
}