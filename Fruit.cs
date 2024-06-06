using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject Whele;
    public GameObject Sliced;

    public Rigidbody TopPartRigetbody;
    public Rigidbody ButtonPartRigetbody;

    private Collider _mainCollider;
    private Rigidbody _mainRigidbody;

    private void Start()
    {
        FillComponets();
    }

    private void FillComponets()
    {
        _mainCollider = GetComponent<Collider>();
        _mainRigidbody = GetComponent<Rigidbody>();
    }

    public void slices(Vector3 direction, Vector3 position, float force)
    {
        SetSliced();

        AddForce(TopPartRigetbody, direction, position, force);
        AddForce(ButtonPartRigetbody, direction, position, force);
    }

    private void AddForce(Rigidbody body, Vector3 position, Vector3 direction, float force)
    {
        body.velocity = _mainRigidbody.velocity;
        body.angularVelocity = _mainRigidbody.angularVelocity;

        body.AddForceAtPosition(direction * force, position,ForceMode.VelocityChange);
    }

    private void SetSliced()
    {
        Whele.SetActive(false);
        Sliced.SetActive(true);

        _mainCollider.enabled = false;
    }

    
}
