using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    // instance라는 변수를 static으로 선언을 하여 다른 오브젝트 안의 스크립트 에서도 instatnce
    // 를 불러올 수 있게 한다.
    public static ObjectPooling instance; // 오브젝트 풀링 사용할 instance
   public GameObject Object_Prefab; // 받아올 게임 오브젝트
   // 적 총을 담아둘 큐를 선언한다.
   public Queue<GameObject> Object_Queue = new Queue<GameObject>();
   
   private void Awake(){
    instance = this;
    Initiallize();
   }

   //오브젝트 생성한다.
   private GameObject CreateNewObject(){
    //오브젝트를 가져와서 인스턴스로 생성한다.
      var newObj = Instantiate(Object_Prefab,GameObject.Find("GameObjs").transform);
      newObj.gameObject.SetActive(false);
      return newObj;
   }

   // 생성한 오브젝트을 큐에 넣는다.
   private void Initiallize(){
    for(int i=0;i<5;i++){
        Object_Queue.Enqueue(CreateNewObject());
    }
   }

   // 총알을 담아둔 큐가 있을 경우 하나를 뽑아서 obj에 할당한 후
   // 보이게 만든 후 리턴한다.
   public static GameObject GetObject()
   {
    Debug.Log($"큐 크기 : {instance.Object_Queue.Count}");
    if(instance.Object_Queue.Count>0){
        var obj = instance.Object_Queue.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }
    
    else{
        // 큐가 없다면 새로 만들어서 obj에 할당한 후 리턴한다.
        Debug.Log("큐없을떄");
        var obj = instance.CreateNewObject();
       //s obj.transform.SetParent(null);
        obj.gameObject.SetActive(true);
        return obj;
    }

   }
   // 사용한 오브젝트을 안보이게 만든 후 큐에 넣는다.
   public static void ReturnObject(GameObject enemyBullet){
    enemyBullet.gameObject.SetActive(false);
    //enemyBullet.transform.SetParent(instance.transform);
    instance.Object_Queue.Enqueue(enemyBullet);
   }
}
