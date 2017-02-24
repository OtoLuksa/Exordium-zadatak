using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	public static Vector2 GetMovementInput ()
	{
	    Vector2 movementInput;

        #if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_WEBGL

            movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        #endif

        return movementInput;
    }
}
