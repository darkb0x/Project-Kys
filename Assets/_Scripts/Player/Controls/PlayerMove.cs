using ProjectKYS.Infrasturcture.Services.Input;
using System;
using UnityEngine;

namespace ProjectKYS.Player.Controls
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;

        [Header("Speed")]
        [SerializeField] private float _walkSpeed = 1;

        [Header("Other")]
        [SerializeField] private float _smoothMoveTime = 0.1f;
        [SerializeField] private float _gravity = 18;

        public bool CanMoving = true;
        public MoveState State => _state;

        public enum MoveState { Stay, Walking }

        private IInputService _inputService;
        private Vector3 _velocity;
        private Vector3 _smoothV;
        private Vector2 _input;
        private MoveState _state;
        private float _currentSpeed;
        private float _verticalVelocity;

        public Vector3 Velocity => _characterController.velocity;

        public void Initialize(IInputService inputService)
        {
            _inputService = inputService;
            CanMoving = true;
        }

        private void Update()
        {
            if(CanMoving)
                Move();
            else
                _state = MoveState.Stay;

            Animate();
        }

        public void ResetVelocity() => 
            _velocity = Vector2.zero;
        public void SetPositionAndRotation(Vector3 position, Vector3 rotationEulerAngles) 
        {
            _characterController.enabled = false;
            transform.position = position;
            transform.eulerAngles = rotationEulerAngles;
            _characterController.enabled = true;
        }

        private void ReadInput()
        {  
            _currentSpeed = _walkSpeed;
            _state = MoveState.Walking;
            
            _input = _inputService.GetPlayerInputHandler().GetMovement();

            if (_input.magnitude == 0)
                _state = MoveState.Stay;
            
            Vector3 inputDirection = new Vector3(_input.x, 0, _input.y).normalized;
            Vector3 worldInputDirection = transform.TransformDirection(inputDirection);
            Vector3 targetVelocity = worldInputDirection * _currentSpeed;

            _velocity = Vector3.SmoothDamp(_velocity, targetVelocity, ref _smoothV, _smoothMoveTime);
            _verticalVelocity -= _gravity * Time.deltaTime;
            _velocity = new Vector3(_velocity.x, _verticalVelocity, _velocity.z);
        }

        private void Move()
        {
            ReadInput();

            CollisionFlags flags = _characterController.Move(_velocity * Time.deltaTime);
            if (flags == CollisionFlags.Below)
            {
                _verticalVelocity = 0;
            }
        }

        private void Animate()
        {

        }
    }
}
