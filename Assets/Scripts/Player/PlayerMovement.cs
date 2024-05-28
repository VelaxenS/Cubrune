using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed => moveSpeed;
    [SerializeField] private float moveSpeed = 3f;
    private CharacterController characterController;
    private Vector2 moveDirection;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        UpdatePosition();
    }

    private void GetInput()
    {
        float xInput, yInput;
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        moveDirection = new Vector2(xInput, yInput);
    }

    private void UpdatePosition()
    {
        GetInput();
        if (moveDirection.magnitude > 1) moveDirection.Normalize();
        characterController.Move(moveDirection * Time.deltaTime * moveSpeed);
    }

}
