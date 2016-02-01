#pragma strict

var motionBlur : UnityStandardAssets.ImageEffects.MotionBlur;
var beerCup : GameObject[];
var maxCup : int;

function Start () {
    motionBlur = GameObject.Find("Main Camera Left").GetComponent(UnityStandardAssets.ImageEffects.MotionBlur);
    motionBlur.enabled = false;
    beerCup = GameObject.FindGameObjectsWithTag("BeerCup");
    maxCup = beerCup.length;
}

function Update () {
    beerCup = GameObject.FindGameObjectsWithTag("BeerCup");
    if(beerCup.length < maxCup - 3)
    {
        motionBlur.enabled = true;
    }
}