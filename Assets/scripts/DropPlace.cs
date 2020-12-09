// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class DropPlace : MonoBehaviour, IDropHandler
// {
//     public void OnDrop(PointerEventData eventData)
//     {
//         CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
//         if(card != null)
//         {
//             card.defaultParent = this.transform;
//         }
//     }
// }

// using UnityEngine;
// using UnityEngine.EventSystems;

// public class DropArea : MonoBehaviour, IDropHandler
// {
//     public void OnDrop(PointerEventData data){
//         Debug.Log(gameObject.name);

//         CardMovement dragObj = data.pointerDrag.GetComponent<CardMovement>();
//         if(dragObj != null){
//             dragObj.parentTransform = this.transform;
//             Debug.Log(gameObject.name+"に"+data.pointerDrag.name+"をドロップ");
//         }       
//     }
// }