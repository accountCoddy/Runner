using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private CharacterController _characterController;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _characterController.Move(Input.GetAxis("Horizontal") * Vector3.right * _speed * Time.deltaTime);
    }
}
