using Unity.Entities;

namespace RotateCube
{
    public struct SpawnerFromEntity : IComponentData
    {
        public Entity prefab;
        public float maxDistanceFromSpawner;
        public float secondsBetweenSpawns;
        public float secondsUntilNextSpawn;
    }
}