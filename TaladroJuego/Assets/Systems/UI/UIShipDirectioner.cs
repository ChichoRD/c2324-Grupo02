using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using MovementSystem.Facade;
using UnityEngine.UIElements;

namespace UISystem
{
    internal class UIShipDirectioner : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Transform ship;
        [SerializeField] private GameObject movementFacade;
        private IMovementFacade<Vector2> shipRotationMovementFacade;

        private bool directionerDragged = false;

        [SerializeField] private float smoothSpeed = 3f;
        private void Awake()
        {
            shipRotationMovementFacade = movementFacade.GetComponent<IMovementFacade<Vector2>>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            directionerDragged = true;
            //print("pointerdown");
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            directionerDragged = false;
            //print("pointerup");
        }

        public void OnDrag(PointerEventData eventData)
        {
            //Vector3 UIElementPosition = new Vector3((transform.position.x + 10) / (10 * 2), (transform.position.y + 10 / (640 / 360)) / (10 / (640 / 360) * 2), 0.0f);
            transform.up = (Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue()) - new Vector3(0.87f, 0.18f, 0.0f)).normalized;
        }

        private void FixedUpdate()
        {
            
            if (shipRotationMovementFacade != null)
            {
                if (directionerDragged)
                    shipRotationMovementFacade.Move(transform.up);
                else { transform.rotation = Quaternion.Slerp(transform.rotation, ship.rotation, Time.deltaTime * smoothSpeed);
                     }
            }
        }
    }
}


