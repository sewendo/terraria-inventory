using System;
using System.Collections;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    private static Vector3 _position;
    private Item _heldItem;
    public static PlayerCursor Instance;
    private bool _holdingItem = false;
    private float _updateCursorTic = 0.01f;
    public static Vector3 Position
    {
        get
        {
            _position = Input.mousePosition;
            return _position;
        }
        private set => _position = value;
    }

    private void Start()
    {
        Cursor.visible = false;
        Instance = this;
        StartCoroutine(UpdateCursor());
        transform.SetAsLastSibling();
    }
    public void Click(ItemSlot itemSlot)
    {
        Item storedItem = itemSlot.storedItem;
        if(_holdingItem)
            Place(storedItem);
        else
            Grab(storedItem);
    }
    
    private void Place(Item storedItem)
    {
        if (storedItem == null)
        {
            storedItem = _heldItem;
            _holdingItem = false;
        }
        else if (storedItem.stackable)
        {
            storedItem.Stack(_heldItem);
            if (_heldItem == null)
                _holdingItem = false;
        }
        else
        {
            SwitchItems(storedItem);
        }


        StopCoroutine(FollowCursor());
    }

    private void SwitchItems(Item itemInItemSlot)
    {
        Item temporaryItem = itemInItemSlot;
        itemInItemSlot = _heldItem;
        _heldItem = temporaryItem;
    }
    private void Grab(Item storedItem)
    {
        _heldItem = storedItem;
        _heldItem.GetComponent<CanvasGroup>().blocksRaycasts = false;
        _heldItem.transform.SetAsLastSibling();
        _holdingItem = true;
        StartCoroutine(FollowCursor());
    }
    private IEnumerator UpdateCursor()
    {
        Instance.transform.position = Position;
        yield return new WaitForSeconds(_updateCursorTic);
        StartCoroutine(UpdateCursor());
    }

    private IEnumerator FollowCursor()
    {
        if (!_holdingItem)
            yield break;
        _heldItem.transform.position = Position;
        yield return new WaitForSeconds(_updateCursorTic);
        StartCoroutine(FollowCursor());
    }
}
