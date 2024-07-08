using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[Serializable]
public class Item
{
    public Cell Cell { get; private set; }

    public ItemView View { get; protected set; }


    public virtual void SetView() { }

    protected virtual string GetPrefabName() { return string.Empty; }

    public virtual void SetCell(Cell cell)
    {
        Cell = cell;
    }

    internal void AnimationMoveToPosition()
    {
        if (View == null) return;

        View.Transform.DOMove(Cell.transform.position, 0.2f);
    }

    public void SetViewPosition(Vector3 pos)
    {
        if (View != null)
        {
            View.Transform.position = pos;
        }
    }

    public void SetViewRoot(Transform root)
    {
        if (View)
        {
            View.Transform.SetParent(root);
        }
    }

    public void SetSortingLayerHigher()
    {
        if (View == null) return;

        // SpriteRenderer sp = View.GetComponent<SpriteRenderer>();
        // if (sp)
        // {
        //     sp.sortingOrder = 1;
        // }

        View.SpriteRenderer.sortingOrder = 1;
    }


    public void SetSortingLayerLower()
    {
        if (View == null) return;

        // SpriteRenderer sp = View.GetComponent<SpriteRenderer>();
        // if (sp)
        // {
        //     sp.sortingOrder = 0;
        // }

        View.SpriteRenderer.sortingOrder = 0;
    }

    internal void ShowAppearAnimation()
    {
        if (View == null) return;

        Vector3 scale = View.Transform.localScale;
        View.Transform.localScale = Vector3.one * 0.1f;
        View.Transform.DOScale(scale, 0.1f);
    }

    internal virtual bool IsSameType(Item other)
    {
        return false;
    }

    internal virtual void ExplodeView()
    {
        if (View != null)
        {
            View.Transform.DOScale(0.1f, 0.1f).OnComplete(
                () =>
                {
                    // GameObject.Destroy(View.gameObject);
                    View.Disable();
                    View = null;
                }
            );
        }
    }
    

    internal void AnimateForHint()
    {
        if (View != null)
        {
            View.Transform.DOPunchScale(View.Transform.localScale * 0.1f, 0.1f).SetLoops(-1);
        }
    }

    internal void StopAnimateForHint()
    {
        if (View != null)
        {
            View.DOKill();
        }
    }

    internal void Clear()
    {
        Cell = null;

        if (View == null) return;
        //GameObject.Destroy(View.gameObject);
        View.Disable();
        View = null;
    }
}
