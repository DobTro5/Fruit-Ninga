using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliser : MonoBehaviour
{
    public Score Score;

    public Health Health;

    private const float minSlicer = 0.01f;

    public float SliceForce = 20;

    private Camera _mainCamera;

    private Collider slicTriger;

    private Vector3 _direction;

    private void Start()
    {
        _mainCamera = Camera.main;
        slicTriger = GetComponent<Collider>();
        SetSlicing(false);
    }

    private void Update()
    {
        Slircing();
    }

    private void OnTriggerEnter(Collider other)
    {
        TrySliceFruit(other);

        TrybangBomb(other);

    }

    private void TrySliceFruit(Collider other)
    {
        Fruit fruit = other.GetComponent<Fruit>();

        if (fruit == null)
        {
            return;
        }
            Score.ChangeScore(1);
            fruit.slices(_direction, transform.position, SliceForce);
        
    }

    private void TrybangBomb(Collider other)
    {
        Bomb bomb = other.GetComponent<Bomb>();

        if (bomb == null)
        {
            return;
        }
            Destroy(bomb.gameObject);
            Score.ChangeScore(-1);

            Health.ChangeHealth(-1);
        
    }

    private void Slircing()
    {
        if (Input.GetMouseButton(0)) 
        {
            Vector3 cursorPaint = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            cursorPaint.z = 0;

            _direction = cursorPaint - transform.position;

            float slicespeed = _direction.magnitude/Time.deltaTime;

            if (slicespeed < minSlicer)
            {
                SetSlicing(false );
                return;
            }

            transform.position = cursorPaint;
            SetSlicing(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            SetSlicing(false);
        }
    }

    private void SetSlicing(bool value)
    {
        slicTriger.enabled = value;
    }
}
