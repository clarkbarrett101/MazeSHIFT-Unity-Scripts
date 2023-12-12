using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;

public class SetMap : MonoBehaviour
{
    public TextAsset[] json;
    private LevelData levelData;
    private int[,] grida = new int[20, 20];
    Color[] colorsA = new Color[3];
    Color[] colorsB = new Color[3];
    private int[,] gridb = new int[20, 20];
    public PrefabLib prefabLib;
    public GameObject[] floors;
    public AudioSource[] audioSource;
    void Awake()
    {
        levelData = JsonUtility.FromJson<LevelData>(json[Player.level].text);
        for (int i = 0; i < 20; i++)
        {
            for (int k = 0; k < 20; k++)
            {
                grida[i, k] = levelData.wallsA[i * 20 + k];
            }
        }

        for (int i = 0; i < 20; i++)
        {
            for (int k = 0; k < 20; k++)
            {
                gridb[i, k] = levelData.wallsB[i * 20 + k];
            }
        }

        for (int i = 0; i < 3; i++)
        {
            colorsA[i ] = new Color(levelData.ColorsA[i * 3], levelData.ColorsA[i * 3 + 1],
                    levelData.ColorsA[i * 3 + 2]);
                colorsB[i ] = new Color(levelData.ColorsB[i * 3], levelData.ColorsB[i * 3 + 1],
                    levelData.ColorsB[i * 3 + 2]);
        }

        for (int i = 0; i < grida.GetLength(0); i++)
        {
            for (int k = 0; k < grida.GetLength(1); k++)
            {
                if(grida[i, k] == 9)
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(i, 0, k);
                else if (grida[i, k] > 0)
                {
                    GameObject tile = prefabLib.GetPrefab(grida[i, k]);
                    tile = Instantiate(tile, new Vector3(i, 0, k), tile.transform.rotation);
                    if (grida[i, k] < 4)
                    {
                        tile.GetComponent<Block>().color = colorsA[grida[i, k] - 1];
                    }
                }
            }
        }

        for (int i = 0; i < gridb.GetLength(0); i++)
        {
            for (int k = 0; k < gridb.GetLength(1); k++)
            {

                if(gridb[i, k] == 9)
                    GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(i, 1, k);
                else if (gridb[i, k] > 0)
                {
                    GameObject tile = prefabLib.GetPrefab(gridb[i, k]);
                    tile = Instantiate(tile, new Vector3(i, 1, k), tile.transform.rotation);
                    if (gridb[i, k] < 4)
                    {
                        tile.GetComponent<Block>().color = colorsB[gridb[i, k] - 1];
                    }
                }
            }
        }

            floors[0].GetComponent<Renderer>().material.color = Color.Lerp(colorsA[0], Color.black, 0.75f);
            floors[1].GetComponent<Renderer>().material.color = Color.Lerp(colorsA[0], Color.black, 0.5f);
            floors[2].GetComponent<Renderer>().material.color = Color.Lerp(colorsB[0], Color.black, 0.75f);
            floors[3].GetComponent<Renderer>().material.color = Color.Lerp(colorsB[0], Color.black, 0.5f);
            audioSource[0].clip = prefabLib.music[(Player.level * 2)% prefabLib.music.Length];
            audioSource[0].Play();
            audioSource[1].clip = prefabLib.music[(Player.level*2+1)% prefabLib.music.Length];
            audioSource[1].Play();
            Player.color1 = colorsA[2];
            Player.color2 = colorsB[2];
    }

}