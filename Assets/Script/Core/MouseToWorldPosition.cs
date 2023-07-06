using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTS.Core
{
    public class MouseToWorldPosition : MonoBehaviour
    {

        [SerializeField] LayerMask mousePlaneLayerMask;
        private static MouseToWorldPosition instance;

        private void Awake()
        {
            instance = this;
        }

        public Vector3 GetMousePosition()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, instance.mousePlaneLayerMask);
            return hit.point;
        }
    } 
}
