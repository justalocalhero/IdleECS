using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Unity.Mathematics;

namespace IdleECS
{
    public class ExperienceAddSystem : ComponentSystem
    {
        protected override void OnUpdate()
        {
            float experienceToAdd = 0;

            Entities.ForEach((ref CurrencyAdder adder, ref Experience experience) =>
            {
                experienceToAdd += adder.toAdd;
            });

            if(experienceToAdd == 0) return;

            Entities.ForEach((ref Experience experience, ref Currency currency) =>
            {
                currency.value += experienceToAdd;
            });
        }
    }
}