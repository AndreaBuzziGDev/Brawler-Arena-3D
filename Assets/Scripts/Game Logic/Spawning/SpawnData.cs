using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnData
{
    //DATA
    public EntityWithHealth TargetPrefab { get; }
    public int Quantity { get; }


    //CONSTRUCTOR
    public SpawnData(EntityWithHealth targetPrefab, int quantity)
    {
        this.TargetPrefab = targetPrefab;
        this.Quantity = quantity;
    }

    //FACTORY
    public static List<SpawnData> GetDataFromRate(List<SpawnRateData> rateData)
    {
        List<SpawnData> result = new();
        foreach(SpawnRateData singleRate in rateData)
            result.Add(GetDataFromRate(singleRate));

        return result;
    }

    public static SpawnData GetDataFromRate(SpawnRateData singleRate)
    {
        int calculatedRate = singleRate.Quantity + UnityEngine.Random.Range(-singleRate.Variance, singleRate.Variance);
        return new SpawnData(
            singleRate.TargetEntityPrefab, 
            Mathf.Clamp(calculatedRate, 0, singleRate.Quantity + singleRate.Variance)
        );
    }
}
