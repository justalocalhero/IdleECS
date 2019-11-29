using Unity.Entities;
using Unity.Mathematics;

namespace IdleECS
{
    public struct Velocity : IComponentData
    {
        public float3 value;
    }
}