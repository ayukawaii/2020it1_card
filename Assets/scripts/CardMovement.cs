// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

//     // public class CardMovement : MonoBehaviour, IDragHandler
//     // {
//     //     public void OnDrag(PointerEventData eventData)
//     //     {
//     //         transform.position = eventData.position;
//     //     }
//     // }

// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;
// // using UnityEngine.EventSystems;

// // public class CardMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
// //     public Transform parentTransform;
// //     public void OnBeginDrag(PointerEventData data){
// //         Debug.Log("OnBeginDrag");
// //         GetComponent<CanvasGroup>().blocksRaycasts = false;
// //         parentTransform = transform.parent;
// //         transform.SetParent(transform.parent.parent);

// //     }
// //     public void OnDrag(PointerEventData data){
// //         transform.position = data.position;
// //     }
// //     public void OnEndDrag(PointerEventData data){
// //         Debug.Log("OnEndDrag");
// //         transform.SetParent(parentTransform);
// //         GetComponent<CanvasGroup>().blocksRaycasts = true;
// //     }   
// // }

// public class CardMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     // public void Start(){
//     //     Debug.Log("start");
//     // }
//     public Transform defaultParent;

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         Debug.Log("OnBeginDrag");
//         defaultParent = transform.parent;
//         transform.SetParent(defaultParent.parent, false);
//          GetComponent<CanvasGroup>().blocksRaycasts = false;

//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//          Debug.Log("OnDrag");
//         transform.position = eventData.position;
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//          Debug.Log("OnEndDrag");
//         transform.SetParent(defaultParent, false);
//          GetComponent<CanvasGroup>().blocksRaycasts = true;
//     }
// // public class CardMovement : MonoBehaviour
// // {

// //     public Vector3 screenPoint;
// //     public Vector3 offset;
    
// //     void OnMouseDown() {
// //     this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
// //     this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
// //     }

// //     void OnMouseDrag() {
// //     Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
// //     Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
// //     transform.position = currentPosition;
// //     }
    
//     // public void OnPointerDown(PointerEventData eventData)
//     // {
//     //     Debug.Log("OnPointerDown");
//     // }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardMovement : MonoBehaviour, IDragHandler
{
      public void OnDrag(PointerEventData eventData)
    {
         Debug.Log("OnDrag");
         transform.position = eventData.position;
    }
}