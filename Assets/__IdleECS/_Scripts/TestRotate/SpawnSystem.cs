using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

namespace RotateCube
{
    public class SpawnSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            float deltaTime = Time.DeltaTime;
            Unity.Mathematics.Random random = new Unity.Mathematics.Random((uint)UnityEngine.Random.Range(0, int.MaxValue));

            Entities.ForEach((ref SpawnerFromEntity spawner, ref LocalToWorld localToWorld) =>
            {
                spawner.secondsUntilNextSpawn -= deltaTime;

                if(spawner.secondsUntilNextSpawn >= 0) { return; }

                spawner.secondsUntilNextSpawn += spawner.secondsBetweenSpawns;

                Entity instance = EntityManager.Instantiate(spawner.prefab);
                EntityManager.SetComponentData(instance, new Translation
                {
                    Value = localToWorld.Position + random.NextFloat3Direction() * random.NextFloat() * spawner.maxDistanceFromSpawner
                });
            });
        }
    }
}