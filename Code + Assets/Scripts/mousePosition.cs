using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePosition : MonoBehaviour {

   [SerializeField] private Camera mainCamera;

   private void Update() {
        Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        Vector3 mouseworldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseworldPosition.z = 0f;
        transform.position = mouseworldPosition;
   }    

}
