#pragma strict

var motionBlur : UnityStandardAssets.ImageEffects.MotionBlur;
var gameObjectff : GameObject[];
var maxCup : int;

function Start () {
	motionBlur = GameObject.Find("Main Camera Right").GetComponent(UnityStandardAssets.ImageEffects.MotionBlur);
	motionBlur.enabled = false;
	gameObjectff = GameObject.FindGameObjectsWithTag("BeerCup");
	maxCup = gameObjectff.length;
}

function Update () {
	gameObjectff = GameObject.FindGameObjectsWithTag("BeerCup");
	if(gameObjectff.length < maxCup)
	{
	  motionBlur.enabled = true;
	}
}