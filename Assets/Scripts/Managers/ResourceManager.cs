using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    int mTreeAmount;
    int mTreeLimit;
    int mStoneAmount;
    int mStoneLimit;
    int mGoldAmount;
    int mGoldLimit;

    public ResourceManager()
    {
        mTreeAmount = 10;
        mTreeLimit = 1000;
        mStoneAmount = 10;
        mStoneLimit = 1000;
        mGoldAmount = 10;
        mGoldLimit = 1000;
    }

    //Checks if there are enough resources for a specific task
    public bool requestResourceUsage(int tree, int stone, int gold)
    {
        if (tree <= mTreeAmount && stone <= mStoneAmount && gold <= mGoldAmount)
        {
            mTreeAmount -= tree;
            mStoneAmount -= stone;
            mGoldAmount -= gold;
            return true;
        }
        return false;
    }

    #region getters
    public int getTreeAmount() { return mTreeAmount; }
    public int getTreeLimit() { return mTreeLimit; }
    public int getStoneAmount() { return mStoneAmount; }
    public int getStoneLimit() { return mStoneLimit; }
    public int getGoldAmount() { return mGoldAmount; }
    public int getGoldLimit() { return mGoldLimit; }
    #endregion
}
