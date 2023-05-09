using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicknDragWaterCan : MonoBehaviour
{
    private GameObject _object;
    private Vector3 offset;
    private Rigidbody2D _rb2d;
    public Animator animator;
    public GameObject water;
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
                Debug.Log(targetObject.tag);
                if (targetObject.tag == "WaterCan" && animator) {
                    animator.SetBool("IsWatering", true);
                    water.SetActive(true);
                }
                
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
            if (animator) {
                    animator.SetBool("IsWatering", false);
            }
            water.SetActive(false);
        }
    }
}
