using Unity.Entities;

namespace IdleECS
{
    public struct CurrencyAdder : IComponentData
    {
        public float toAdd;
    }
}