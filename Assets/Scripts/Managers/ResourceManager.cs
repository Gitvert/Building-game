using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int _treeAmount;
    private int _treeLimit;
    private int _stoneAmount;
    private int _stoneLimit;
    private int _goldAmount;
    private int _goldLimit;

    public ResourceManager()
    {
        _treeAmount = 10;
        _treeLimit = 1000;
        _stoneAmount = 10;
        _stoneLimit = 1000;
        _goldAmount = 10;
        _goldLimit = 1000;
    }

    //Checks if there are enough resources for a specific task
    public bool RequestResourceUsage(int tree, int stone, int gold)
    {
        if (tree > _treeAmount || stone > _stoneAmount || gold > _goldAmount)
        {
            return false;
        }
        
        _treeAmount -= tree;
        _stoneAmount -= stone;
        _goldAmount -= gold;
        
        return true;
    }

    #region getters
    public int GetTreeAmount() { return _treeAmount; }
    public int GetTreeLimit() { return _treeLimit; }
    public int GetStoneAmount() { return _stoneAmount; }
    public int GetStoneLimit() { return _stoneLimit; }
    public int GetGoldAmount() { return _goldAmount; }
    public int GetGoldLimit() { return _goldLimit; }
    #endregion
}
