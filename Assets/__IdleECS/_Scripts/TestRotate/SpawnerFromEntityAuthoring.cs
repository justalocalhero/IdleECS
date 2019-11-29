using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace RotateCube
{
    public class SpawnerFromEntityAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private float maxDistanceFromSpawner;
        [SerializeField] private float spawnsPerSecond;
        [SerializeField] private float secondsUntilNextSpawn;


        public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        {
            referencedPrefabs.Add(prefab);
        }

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            dstManager.AddComponentData(entity, new SpawnerFromEntity
            {
                prefab = conversionSystem.GetPrimaryEntity(prefab),
                maxDistanceFromSpawner = maxDistanceFromSpawner,
                secondsBetweenSpawns = 1 / spawnsPerSecond,
                secondsUntilNextSpawn = secondsUntilNextSpawn
            });
        }

    }
}