using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Testing
{
    public class ClusterTest : MonoBehaviour
    {
        public Values values;
        public int cost, baseTime;

        [Space(20)]
        public int upgradeCount, restTime, completeTime, incomeIncrease;

        public float maxIncome;

        public List<int> upgradeCosts = new List<int>();

        void OnValidate()
        {
            upgradeCosts = new List<int>();
            Chain chain = new Chain(cost, baseTime, values);

            Cluster cluster = new Cluster(chain, upgradeCount, restTime, completeTime, incomeIncrease);

            foreach(Upgrade upgrade in cluster.upgrades)
            {
                upgradeCosts.Add(upgrade.cost);
            }

            maxIncome = chain.MaxIncome();
        }
    }

    public class Cluster
    {
        public List<Upgrade> upgrades = new List<Upgrade>();

        public Cluster(Chain chain, int upgradeCount, float restTime, float completeTime, float incomeIncrease)
        {
            float individualTime = completeTime / upgradeCount;
            float individualIncrease = incomeIncrease / upgradeCount;

            float startIncome = chain.MaxIncome();
            int restCost = Mathf.CeilToInt(startIncome * restTime);

            for(int i = 0; i < upgradeCount; i++)
            {
                float maxIncome = chain.MaxIncome();
                int cost = restCost + Mathf.CeilToInt(maxIncome * individualTime);

                Upgrade upgrade = new AdditiveValueUpgrade(chain, cost, individualIncrease);

                upgrades.Add(upgrade);
                chain.upgrades.Add(upgrade);
            }
        }
    }

    public class Upgrade
    {
        public Values values;

        public int cost;

        public Upgrade(int cost, Values values)
        {
            this.values = values;
            this.cost = cost;
        }
    }

    public class AdditiveValueUpgrade : Upgrade
    {
        public AdditiveValueUpgrade(Chain chain, int cost, float incomeIncrease) 
            : base(cost, new Values { addPercent = AddPercentForIncomeIncrease(chain, incomeIncrease)})
        {

        }

        public static float AddPercentForIncomeIncrease(Chain chain, float incomeIncrease)
        {
            Values v = chain.ValuesAtIndex(chain.upgrades.Count);
            
            float targetIncome = incomeIncrease + chain.IncomeAtValues(v);
            
            float addPercentIncrease = ((targetIncome * chain.baseTime) / (v.speed * v.resourceValue * v.multPercent)) - v.addPercent;
            
            return Utility.Truncate(addPercentIncrease, 2);
        }
    }

    public class MultiplicativeValueUpgrade : Upgrade
    {
        public MultiplicativeValueUpgrade(Chain chain, int cost, float incomeIncrease) 
            : base(cost, new Values { multPercent = MultPercentForIncomeIncrease(chain, incomeIncrease)})
        {

        }

        public static float MultPercentForIncomeIncrease(Chain chain, float incomeIncrease)
        {
            Values v = chain.ValuesAtIndex(chain.upgrades.Count);
            
            float targetIncome = incomeIncrease + chain.IncomeAtValues(v);
            
            float multPercentIncrease = ((targetIncome * chain.baseTime) / (v.speed * v.resourceValue * v.addPercent)) / v.multPercent;

            return Utility.Truncate(multPercentIncrease, 2);
        }
    }

    public class FlatValueUpgrade : Upgrade
    {
        public FlatValueUpgrade(Chain chain, int cost, float incomeIncrease) 
            : base(cost, new Values { resourceValue = FlatValueForIncomeIncrease(chain, incomeIncrease)})
        {

        }
        public static float FlatValueForIncomeIncrease(Chain chain, float incomeIncrease)
        {
            Values v = chain.ValuesAtIndex(chain.upgrades.Count);
            
            float targetIncome = incomeIncrease + chain.IncomeAtValues(v);
            
            float resourceValueIncrease = ((targetIncome * chain.baseTime) / (v.speed * v.addPercent * v.multPercent)) - v.resourceValue;

            return Utility.Truncate(resourceValueIncrease, 2);
        }
    }

    public class SpeedUpgrade : Upgrade
    {
        public SpeedUpgrade(Chain chain, int cost, float incomeIncrease) 
            : base(cost, new Values { speed = SpeedForIncomeIncrease(chain, incomeIncrease)})
        {

        }

        public static float SpeedForIncomeIncrease(Chain chain, float incomeIncrease)
        {
            Values v = chain.ValuesAtIndex(chain.upgrades.Count);
            
            float targetIncome = incomeIncrease + chain.IncomeAtValues(v);
            
            float speedIncrease = ((targetIncome * chain.baseTime) / (v.resourceValue * v.addPercent * v.multPercent)) - v.speed;

            return Utility.Truncate(speedIncrease, 2);
        }
    }

    public class Chain
    {
        public float baseTime;

        private int cost;

        private Values baseValues;

        public List<Upgrade> upgrades = new List<Upgrade>();

        public Chain(int cost, int baseTime, Values baseValues)
        {
            this.cost = cost;
            this.baseTime = baseTime;
            this.baseValues = baseValues;
        }

        public float MaxIncome()
        {
            return IncomeAtIndex(upgrades.Count);
        }

        public float IncomeAtIndex(int index)
        {
            return IncomeAtValues(ValuesAtIndex(index));
        }

        public float IncomeAtCost(int cost)
        {
            return IncomeAtIndex(IndexAtCost(cost));
        }
        
        public int IndexAtCost(int cost)
        {
            int index = 0;

            foreach(Upgrade upgrade in upgrades)
            {
                if(upgrade.cost > cost) return index;
                index++;
            }

            return index;
        }

        public Values ValuesAtIndex(int index)
        {
            int clampedIndex = Mathf.Clamp(index, 0, upgrades.Count);

            Values toCalculate = baseValues;

            for(int i = 0; i < clampedIndex; i++)
            {
                toCalculate.Increase(upgrades[i].values);
            }

            return toCalculate;
        }

        public float IncomeAtValues(Values values)
        {
            return values.resourceValue * values.addPercent * values.multPercent / (baseTime / values.speed); 
        }
    }

    [System.Serializable]
    public struct Values
    {
        public float addPercent;
        public float multPercent;
        public float resourceValue;
        public float speed;

        public void Increase(Values toAdd)
        {
            addPercent += toAdd.addPercent;
            multPercent *= (1 + toAdd.multPercent);
            resourceValue += toAdd.resourceValue;
            speed += toAdd.speed;
        }
    }
}