using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class TowerTargeting : MonoBehaviour
{
    private TowerTargetComponent[] _availableTargets;

    public Transform _relTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        _availableTargets = FindObjectsOfType<TowerTargetComponent>();
    }

    
    public TowerTargetComponent FindBestTarget()
    {
        float minDistance = -1.0F;
        TowerTargetComponent validTarget = null;
        
        foreach (TowerTargetComponent potentialTarget in _availableTargets)
        {
            Vector3 t = potentialTarget.transform.position;
            Vector3 relDir = _relTransform.position - t;
            float squareDistance = relDir.sqrMagnitude;
            if (minDistance < -1 || squareDistance < minDistance)
            {
                minDistance = squareDistance;
                validTarget = potentialTarget;
            }
        }

        return validTarget;
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
