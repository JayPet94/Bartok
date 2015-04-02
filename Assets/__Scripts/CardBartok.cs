using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public enum CBState {
	drawpile,
	toHand,
	hand,toTarget,
	target,
	discard,
	to,
	idle
}

public class CardBartok :Card {
	static public float MOVE_DURATION = .5f;
	static public string MOVE_EASING = Easing.InOut;
	static public float CARD_HEIGHT = 3.5f;
	static public float CARD_WIDTH = 2f;

	public CBState state = CBState.drawpile;

	public List<Vector3> bezierPts;
	public List<Quaternion> bezierRots;
	public float timeStart, timeDuration;

	public GameObject reportFinishTo = null;

	public void MoveTo(Vector3 ePos, Quaternion eRot){
		bezierPts = new List<Vector3> ();
		bezierPts.Add (transform.localPosition);
		bezierPts.Add (ePos);
		bezierRots = new List<Quaternion>();
		bezierRots.Add (transform.rotation);
		bezierRots.Add (eRot);

		if(timeStart == 0){
			timeStart = Time.time;
		}

		timeDuration = MOVE_DURATION;

		state = CBState.to;
	}	
}
