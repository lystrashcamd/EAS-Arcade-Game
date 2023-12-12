using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
   public Transform[] kueObj;
   static public string spawnedYet = "n";
   static public Vector2 spawnerPos;
   static public Vector2 spawnPos; 
   static public string newKue = "n";
   static public int whichKue=0;
   bool firstSpawn = true;
   public GameObject checkBGameObject;
   public bool checkBActivated { get; private set; } = false;
    
   void Start()
   {

   } 


   void Update ()
   {
    if (firstSpawn || Input.GetMouseButtonUp(0)) // Check for mouse button release or first spawn
    {
        spawnKue(); // Trigger spawn on mouse up or first spawn
    }
    replaceKue(checkBGameObject);
   }

   void spawnKue()
   {
    if (spawnedYet == "n")
    {
        StartCoroutine(spawntimer());
        spawnedYet = "w";
        firstSpawn = false;
    }
   }

    public void replaceKue(GameObject checkB)
    {
        if (newKue == "y")
        {
            newKue = "n";
            Transform newTransform = Instantiate(kueObj[whichKue + 1], spawnPos, Quaternion.identity);
            GameObject newObject = newTransform.gameObject;
            DragAndDrop dragAndDrop = newObject.GetComponent<DragAndDrop>();
            if (dragAndDrop != null)
            {
                dragAndDrop.SetDraggable(false);
            }

            if (newObject.CompareTag("9") && checkB != null)
            {
                checkB.SetActive(true); // Activate Check B if the spawned object has the tag "2"
                checkBActivated = true;
            }
        }
    }

    public bool IsCheckBActivated()
    {
        return checkBActivated;
    }

   IEnumerator spawntimer()
    {
        yield return new WaitForSeconds(2.0f);

        if (!Input.GetMouseButton(0)) // Check if the mouse button is still not pressed
        {
            Instantiate(kueObj[Random.Range(0, 5)], transform.position, Quaternion.identity);
            spawnedYet = "y";
        }
    }

}