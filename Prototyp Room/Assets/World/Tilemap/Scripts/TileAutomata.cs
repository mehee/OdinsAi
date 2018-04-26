using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class TileAutomata : MonoBehaviour {


    [Range(0,100)]
    public int initChanceWater;
    [Range(1,8)]
    public int birthLimit;
    [Range(1,8)]
    public int deathLimit;

    [Range(1,10)]
    public int numR;
    public Vector3Int tmpSize;

    private int count = 0;
    private int[,] terrainMap;

    [SerializeField]
    private Tilemap groundMap;
    [SerializeField]
    private Tilemap waterMap;
    [SerializeField]
    private Tile groundTile;
    [SerializeField]
    private Tile waterTile;

    int width, height;

    public void doSimulation(int nu)
    {
        clearMap(false);
        width = tmpSize.x;
        height = tmpSize.y;

        if (terrainMap==null)
            {
                terrainMap = new int[width, height];
                initPos();
            }


        for (int i = 0; i < nu; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x, y] == 1)
                {
                    waterMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), waterTile);
                }
                else
                {
                    groundMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), groundTile);
                }
            }
        }


    }

    public void initPos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 101) < initChanceWater ? 1 : 0;
            }

        }

    }


    public int[,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width,height];
        int neightbour;
        BoundsInt myB = new BoundsInt(-1, -1, 0, 3, 3, 1);


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                neightbour = 0;
                foreach (var b in myB.allPositionsWithin)
                {
                    if (b.x == 0 && b.y == 0) // it self
					{
						continue;
					}
                    if (x+b.x >= 0 && x+b.x < width && y+b.y >= 0 && y+b.y < height)
                    {
                        neightbour += oldMap[x + b.x, y + b.y];
                    }
                    else//reached border
                    {
                        neightbour++;
                    }
                }
				// checking the Tiles on the oldMap (1 means on Map, 0 not on Map)
                if (oldMap[x,y] == 1)
                {
                    if (neightbour < deathLimit) // lower then deathLimit of 8
					{
						newMap[x, y] = 0;// will not be on our newMap
					}

                    else
                    {
                        newMap[x, y] = 1;// transfered to our newMap
                    }
                }

                if (oldMap[x,y] == 0)
                {
                    if (neightbour > birthLimit) // higher then birthLimit of max 8
                    {
                        newMap[x, y] = 1; // will not be on our newMap
                    }           
                    else
                    {
                        newMap[x, y] = 0; // transfered to our newMap
                    }
                }

            }

        }

        return newMap;
    }

	// Update is called once per frame
	void Update () 
    {

        if (Input.GetMouseButtonDown(0))
        {
            doSimulation(numR);
        }


        if (Input.GetMouseButtonDown(1))
        {
            clearMap(true);
        }
		//Save map as Prefab
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveAssetMap();
            count++;
        }

    }


    public void SaveAssetMap()
    {
        string saveName = "Map_" + count;
        var mf = GameObject.Find("Grid");

        if (mf)
        {
            var savePath = "Assets/Prefabs/" + saveName + ".prefab";
            if (PrefabUtility.CreatePrefab(savePath,mf))
            {
                EditorUtility.DisplayDialog("Tilemap saved", "Tilemap saved under" + savePath, "Continue");
            }
            else
            {
                EditorUtility.DisplayDialog("Tilemap NOT saved", "An ERROR occured while trying to saveTilemap under" + savePath, "Continue");
            }
        }
    }

    public void clearMap(bool complete)
    {

        groundMap.ClearAllTiles();
        waterMap.ClearAllTiles();
        if (complete)
        {
            terrainMap = null;
        }


    }



}
