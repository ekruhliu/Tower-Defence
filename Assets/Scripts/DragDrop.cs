using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    private Vector3 offset;
    private GameObject prefab;
    private GameObject prefab2;
    [SerializeField] private GameObject typeDrag;
    [SerializeField] private GameObject typePut;
    private Image im;

    private void Awake()
    {
        im = GetComponent<Image>();
    }

    private void Update()
    {
        if (gameManager.gm.playerEnergy < typePut.GetComponent<towerScript>().energy)
            im.color = new Color(200f, 0f, 0f);
        else
            im.color = new Color(255f, 255f, 255f);
    }

    void OnMouseDown()
    {
        if (gameManager.gm.playerEnergy >= typePut.GetComponent<towerScript>().energy)
        {
            prefab = Instantiate(typeDrag, transform.position, Quaternion.identity);
            offset = prefab.transform.position -
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
    }

    void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
        prefab.transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        prefab.transform.position = new Vector3(prefab.transform.position.x, prefab.transform.position.y, -1);
    }

    private void OnMouseUp()
    {
        RaycastHit2D hit = Physics2D.Raycast(prefab.transform.position, Vector2.zero);
        try
        {
            if (hit.transform.tag != null)
            {
               if (hit.transform.tag.Equals("empty"))
               {
                   prefab2 = Instantiate(typePut, prefab.transform.position, Quaternion.identity);
                   prefab2.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, -1);
                   gameManager.gm.playerEnergy -= prefab2.GetComponent<towerScript>().energy;
                   hit.transform.tag = "tile";
                   Destroy(prefab);
               } 
            }
        }
        catch (Exception)
        {
            Destroy(prefab);
            return;
        }
        if(prefab != null)
            Destroy(prefab);
    }
}
