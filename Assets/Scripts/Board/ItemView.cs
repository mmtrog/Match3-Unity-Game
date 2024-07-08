using DG.Tweening;
using UnityEngine;

public class ItemView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_renderer;

    [SerializeField] private Transform m_transform;

    [SerializeField] private ItemSO m_data;
    
    public Transform Transform => m_transform;

    public SpriteRenderer SpriteRenderer => m_renderer;
    
    public void SetType(NormalItem.eNormalType itemType)
    {
        m_renderer.sprite = m_data.sprites[(int)itemType];
        
        gameObject.SetActive(true);
    }
    
    public void SetType(BonusItem.eBonusType itemType)
    {
        m_renderer.sprite = m_data.sprites[(int)itemType + 7];
        
        gameObject.SetActive(true);
    }
    
    public void Disable()
    {
        gameObject.SetActive(false);

        Transform.DOKill();
        
        Transform.localScale = Vector3.one;
        
        PoolManager.Instance.PutInPool(this);
    }
}