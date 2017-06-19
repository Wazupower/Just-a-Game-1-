#pragma strict

public var SpotLight : GameObject;						// l'object correspondant à la lampe
public var IsOn : boolean = false;						// bouléen on/off

function Update () {
	if(Input.GetKeyDown("f")){							// si presse F
		IsOn = !IsOn;									// inverse l'état de la lampe
	}
	if(IsOn == true){									// si vrai lampe allumé
		SpotLight.SetActive(true);
	}else{
		SpotLight.SetActive(false);						// sinon éteint
	}
}