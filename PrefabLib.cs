using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PrefabLib", menuName = "ScriptableObjects/PrefabLib", order = 1)]
public class PrefabLib : ScriptableObject
{
    public GameObject exit;
    public GameObject wall;
    public GameObject[] keys;
    public GameObject[] locks;
    public GameObject[] switches;
    public GameObject[] xblocks;
    public GameObject[] oblocks;
    public AudioClip[] music;
    public GameObject[] promptZones;
        public GameObject GetPrefab(int id)
    {
        switch (id)
        {
            case 1:
                return wall;
            case 2:
                return wall;
            case 3:
                return wall;
            case 4:
                return wall;
            case 5:
                case 6:
                    case 7:
            case 8:
                return exit;
            case 10:
                return keys[0];
            case 11:
                return keys[1];
            case 12:
                return keys[2];
            case 20:
                return locks[0];
            case 21:
                return locks[1];
            case 22:
                return locks[2];
            case 30:
                return switches[0];
            case 31:
                return switches[1];
            case 32:
                return switches[2];
            case 40:
                return xblocks[0];
            case 41:
                return xblocks[1];
            case 42:
                return xblocks[2];
            case 50:
                return oblocks[0];
            case 51:
                return oblocks[1];
            case 52:
                return oblocks[2];
            case 80:
                return promptZones[0];
            case 81:
                return promptZones[1];
            case 82:
                return promptZones[2];
            case 83:
                return promptZones[3];
            case 84:
                return promptZones[4];
            default:
                return null;
        }
    }
}