using UnityEngine;
using Unity.Entities;

namespace IdleECS
{
    public class CurrencyAuthoring : MonoBehaviour
    {
        [SerializeField] private float startingExperience;
        private EntityManager entityManager;

        void Start()
        {
            entityManager = World.Active.EntityManager;

            EntityArchetype experienceArchetype = entityManager.CreateArchetype(
                typeof(Currency),
                typeof(Experience)
            );

            Entity experienceEntity = entityManager.CreateEntity(experienceArchetype);

            entityManager.SetComponentData(experienceEntity, new Currency{
                value = startingExperience
            });

        }
    }
}