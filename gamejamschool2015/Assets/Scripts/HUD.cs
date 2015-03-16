using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	public GameObject scoreObj;
	public GameObject timeObj;

	private Text scoreText;
	private Text timeText;
	private int score = 0;
	private int addScore = 0;
	private float time;

	void Start () {
		scoreText = scoreObj.GetComponent<Text>();
		timeText = timeObj.GetComponent<Text>();
	}

	void Update(){
		if (addScore > 0){
			score ++;
			addScore --;
		}
		if (scoreObj.transform.localScale.x > 1f){
			scoreObj.transform.localScale -= new Vector3(Time.deltaTime,Time.deltaTime,Time.deltaTime)*0.5f;
		}
		time += Time.deltaTime;

		scoreText.text = "Score: " + score.ToString();
		timeText.text = "Time: " + Mathf.RoundToInt(time).ToString();
	}
	
	public void AddScore(int _score){
		addScore += _score;
		scoreObj.transform.localScale = new Vector3(2,2,2);
	}


}
