﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{

  public GameObject hexTilePrefab;
  private GameObject quadObject;
  public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void createHex()
    {
      quadObject = GameObject.Find("Quad(Clone)");
      Debug.Log("I am a "+quadObject.name);
      Renderer rend = quadObject.GetComponent<Renderer>();
      Debug.Log(rend.bounds.max);
      Debug.Log(rend.bounds.min);
      int x = 0;
      int y = 0;
      int z = 0;
      int x0 = 0;
      int y0 = 0;
      int z0 = 0;

      for(float i = rend.bounds.min.x; i <= rend.bounds.max.x;i = i + 0.97f)
      {
        x = x0;
        y = y0;
        z = z0;
        for(float j = rend.bounds.max.z; j >= rend.bounds.min.z; j = j - 0.56f)
        {
          Vector3 center = new Vector3(i,0.4f,j);
          Collider[] hitColliders = Physics.OverlapSphere(center, 0.3f);
          if (hitColliders.Length == 0)
          {
            GameObject temp = Instantiate(hexTilePrefab);
            temp.name = "HexTile ["+x.ToString()+","+y.ToString()+","+z.ToString()+"]";
            temp.transform.position = new Vector3(i,0.1f,j);
            temp.transform.parent = parent.transform;
          }
          Vector3 center1 = new Vector3(i+0.485f,0.4f,j-0.28f);
          Collider[] hitColliders1 = Physics.OverlapSphere(center1, 0.3f);
          if (hitColliders1.Length == 0)
          {
            GameObject temp1 = Instantiate(hexTilePrefab);
            temp1.name = "HexTile ["+(x+1).ToString()+","+(y-1).ToString()+","+z.ToString()+"]";
            temp1.transform.position = new Vector3(i+0.485f,0.1f,j-0.28f);
            temp1.transform.parent = parent.transform;
          }
          y = y - 1;
          z = z + 1;
        }
        x0 = x0 + 2;
        y0 = y0 - 1;
        z0 = z0 - 1;
      }
    }
}
