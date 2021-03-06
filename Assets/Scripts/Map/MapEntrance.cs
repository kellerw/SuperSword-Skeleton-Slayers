﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEntrance : InteractableTile {

    public ContinentType mazeToGenerate;
    public string sceneToLoad;
    public TransitionType transitionType;
    public int entranceID;
    public bool enableDarkness = false;
    public Vector2 exitPosition;
    public bool generateMap = false;

    public bool entersIntoMaze = false;

    public AudioClip playOnExit;

    public override void ActivateInteraction()
    {
        GameManager.gm.GoThruDoor(this, generateMap);
    }

}
