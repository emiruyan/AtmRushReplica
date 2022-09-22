using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Collect"))//Çarptığımız objenin tag'i "Collect" ise;
      {
         //Çarptığımız obje bu classın bağlı olduğu objenin transformuna eşit olacak ve Vector3.forward eklenecek.(Bir ilerisi)
         other.gameObject.transform.position = transform.position + Vector3.forward;
         //Bu objeden CollectController scriptini yok ediyoruz.
         Destroy(gameObject.GetComponent<CollectController>());
         //Çarptığımız objeye CollectController scriptini ekliyoruz.
         other.gameObject.AddComponent<CollectController>();
         //Çarptığımız objenin BoxCollider.isTrigger'ını kapatıyoruz.
         other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
         //Çarptığımız objeye NodeMovement adlı scripti ekliyoruz.
         other.gameObject.AddComponent<NodeMovement>();
         //Çarptığımız objeye NodeMovement içindeki.connectedNode değişkeninin transformunu eşitliyoruzç
         other.gameObject.GetComponent<NodeMovement>().connectedNode = transform;
         //Çarptığımız objenin tag'ını "Collected" yapıyoruz.
         other.gameObject.tag = "Collected";

      }
   }
}
