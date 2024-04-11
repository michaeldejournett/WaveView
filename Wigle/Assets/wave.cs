using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave: MonoBehaviour {
  public GameObject WaveCube;

  public List < GameObject > WaveCubeList = new List < GameObject > ();

  public int cubeIdentifier = 0;

  public float yHeight = 0;

  public static int xWaveSize = 25;
  public int zWaveSize = xWaveSize;
  void Start() {

    createWave(xWaveSize, zWaveSize);
  }

  // Update is called once per frame
  void Update() {
    moveWave();
  }

  public void createCube(Vector3 position) {
    var cube = Instantiate(WaveCube, position, Quaternion.identity) as GameObject;
    cube.name = "WaveCube" + cubeIdentifier;
    cubeIdentifier++;
    WaveCubeList.Add(cube);

  }

  public void createWave(int xWaveSize, int zWaveSize) {
    for (int x = -xWaveSize / 2; x < xWaveSize / 2; x++) {
      for (int z = -zWaveSize / 2; z < zWaveSize / 2; z++) {
        createCube(new Vector3(2 * x, 0, 2 * z));
      }
    }
  }

  public void moveWave() {
    float time = Time.time;
    float waveSpeed = 10f;
    float waveAmplitude = 2f; 
    float waveSize = xWaveSize;

    foreach(var waveCube in WaveCubeList) {
      Vector3 position = waveCube.transform.position;
      float distance = position.magnitude;
      float waveHeight = waveAmplitude * Mathf.Sin((time * waveSpeed - distance) / waveSize * Mathf.PI);
      position.y = waveHeight;
      waveCube.transform.position = position;
    }
  }

}