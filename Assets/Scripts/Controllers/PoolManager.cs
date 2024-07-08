using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    private Queue<ItemView> pool = new Queue<ItemView>();

    private GameObject m_itemViewPrefab;

    private ItemView m_itemView;
    
    private void Start()
    {
        m_itemViewPrefab = Resources.Load<GameObject>("prefabs/ItemView");
    }

    public ItemView SpawnItemView(NormalItem.eNormalType itemType)
    {
        m_itemView = pool.Count <= 0 ? Instantiate(m_itemViewPrefab).GetComponent<ItemView>() : pool.Dequeue();
        
        m_itemView.SetType(itemType);

        return m_itemView;
    }
    
    public ItemView SpawnItemView(BonusItem.eBonusType itemType)
    {
        m_itemView = pool.Count <= 0 ? Instantiate(m_itemViewPrefab).GetComponent<ItemView>() : pool.Dequeue();
        
        m_itemView.SetType(itemType);

        return m_itemView;
    }

    public void PutInPool(ItemView itemView)
    {
        pool.Enqueue(itemView);
    }

    public void ClearPool()
    {
        pool.Clear();
    }
}

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _ins = null;

    public static T Instance
    {
        get
        {
            if (!_ins)
            {
                _ins = FindObjectOfType<T>();
            }
            return _ins;
        }
    }

    protected void Awake()
    {
        if (!_ins)
        {
            _ins = FindObjectOfType<T>();
            OnInitialization();
        }
    }

    public virtual void OnDestroy()
    {
        _ins = null;
        OnExtinction();
    }

    public virtual void OnInitialization() { }
    public virtual void OnExtinction()     { }
}