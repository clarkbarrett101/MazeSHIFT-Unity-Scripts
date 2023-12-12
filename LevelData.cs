using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
        public int[] playerStart ;
        public int[] wallsA;
        public int[] wallsB;
        public float[] ColorsA;
        public float[] ColorsB;
        public int lockCount;
        public int[] lockPositions;
        public int keyCount;
        public int[] keyPositions;
        public int switchCount;
        public int[] switchPositions;
        public int xBlockCount;
        public int[] xBlockPositions;
        public int oBlockCount;
        public int[] oBlockPositions;
        public int[] exitPosition;

}