using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

namespace IdleECS
{
    [UpdateAfter(typeof(SimulationSystemGroup))]
    public class CurrencyAddClearSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((ref CurrencyAdder adder) =>
            {
                adder.toAdd = 0;
            });
        }
    }
}