using Unity.Entities;

namespace RotateCube
{
    public struct Rotate : IComponentData
    {
        public float radiansPerSecond;
    }
}