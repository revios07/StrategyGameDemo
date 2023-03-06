using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFactory : GameObjectFactory<Building>
{
    [SerializeField]
    private TowerScriptable[] _buildingDatas;
    [SerializeField]
    private GameObject[] _buildingPrefabs;

    public override Building GetNewInstance(string gameObjectType)
    {
        for (int i = 0; i < _buildingDatas.Length; ++i)
        {
            if (gameObjectType == _buildingDatas[i].GetTowerData().towerName)
            {
                for (int j = 0; j < _buildingPrefabs.Length; ++j)
                {
                    if (_buildingPrefabs[j].GetComponent<TowerScriptable>().GetTowerData().towerName == gameObjectType)
                    {
                        return Instantiate(_buildingPrefabs[j]).GetComponent<Building>();
                    }
                }
            }
        }

        return null;
        return base.GetNewInstance(gameObjectType);
    }
}
