using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicknDrag : MonoBehaviour
{
    private GameObject _object;
    private Vector3 offset;
    private Rigidbody2D _rb2d;
    private void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                _rb2d = targetObject.GetComponent<Rigidbody2D>();
                _object = targetObject.transform.gameObject;
                offset = _object.transform.position - mousePosition;
            }
        }
        if (_object)
        {
            _object.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && _object)
        {
            _rb2d.velocity = Vector2.zero;
            _rb2d = null;
            _object = null;
        }
    }
}
