using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

	public int life;
	private int startLife;

	void Start(){
		startLife = life;
	}
	public void OnDamage(int damageValue){
		life--;
	}

	public int getStartLife(){
		return startLife;
	}
}
