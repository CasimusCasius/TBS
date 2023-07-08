using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace BTS.Core
{
    public class CameraController : MonoBehaviour
    {
        private const float MIN_Y_CAMERA_OFFSET = 2.0f;
        private const float MAX_Y_CAMERA_OFFSET = 12.0f;

        [Range(0f, 50f)]
        [SerializeField] private float cameraMoveSpeed = 10f;
        [Range(0f, 500f)]
        [SerializeField] private float cameraRotationSpeed = 100f;
        [Range(0f, 5f)]
        [SerializeField] private float cameraZoomStep = .5f;
        [Range(0f, 20f)]
        [SerializeField] private float cameraZoomSpeed = 10f;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        private CinemachineTransposer cinemachineTranposer;
        private Vector3 targetFollowOffset;

        private void Start()
        {
            cinemachineTranposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            targetFollowOffset = cinemachineTranposer.m_FollowOffset;
        }

        private void Update()
        {
            HandleCameraMovement();
            HandleCameraRotation();
            HandleCameraZoom();
        }

        private void HandleCameraMovement()
        {
            Vector3 inputMoveDir = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
                inputMoveDir.z = +1f;

            if (Input.GetKey(KeyCode.S))
                inputMoveDir.z = -1f;

            if (Input.GetKey(KeyCode.A))
                inputMoveDir.x = -1f;

            if (Input.GetKey(KeyCode.D))
                inputMoveDir.x = +1f;

            Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
            transform.position += moveVector * cameraMoveSpeed * Time.deltaTime;
        }

        private void HandleCameraRotation()
        {
            Vector3 rotationVector = Vector3.zero;

            if (Input.GetKey(KeyCode.Q))
                rotationVector.y = -1f;

            if (Input.GetKey(KeyCode.E))
                rotationVector.y = +1f;

            transform.eulerAngles += cameraRotationSpeed * Time.deltaTime * rotationVector;
        }

        private void HandleCameraZoom()
        {
            cinemachineTranposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
            var currentFollowOffset = cinemachineTranposer.m_FollowOffset;

            if (Input.mouseScrollDelta.y > 0)
                targetFollowOffset.y -= cameraZoomStep;
            if (Input.mouseScrollDelta.y < 0)
                targetFollowOffset.y += cameraZoomStep;


            targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_Y_CAMERA_OFFSET, MAX_Y_CAMERA_OFFSET);
            currentFollowOffset = Vector3.Lerp(currentFollowOffset, targetFollowOffset, Time.deltaTime * cameraZoomSpeed);

            cinemachineTranposer.m_FollowOffset = currentFollowOffset;
        }

    }
}
