#pragma strict

var jumpSpeed : float = 100.0;
var updateTime : float = 1.0 / 60.0;
var filterStrength : float = 1.0;
var shakeLimit : float = 1.0;

private var minShakeFilter : float = updateTime / filterStrength;
private var startAcceleration : Vector3 = Vector3.zero;
private var currentAcceleration : Vector3;
private var shake : Vector3;


function Start() {
    shakeLimit *= shakeLimit;
    startAcceleration = Input.acceleration;
}

function Update() {
    currentAcceleration = Input.acceleration;
    startAcceleration = Vector3.Lerp(startAcceleration, currentAcceleration, minShakeFilter);
    shake = currentAcceleration - startAcceleration;
    
    if (shake.sqrMagnitude >= shakeLimit) {
        transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime, Space.World);
    }
}