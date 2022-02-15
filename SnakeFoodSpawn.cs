using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SnakeFoodSpawn : MonoBehaviour
{
public BoxCollider2D gridArea;

    public int randomN;
    public GameObject player;
    public GameObject goal;
    public GameObject false1;
    public GameObject false2;
    public SpriteRenderer goalSprite ,false1Sprite, false2Sprite;
         
    public TextMeshProUGUI correctColor;
    public TextMeshProUGUI scoreMenu;

    public int score=-1;
	public TextMeshProUGUI textCol,textScore;
    public Colorz[] colorz;

    void Start(){

        goalSprite = goal.GetComponent<SpriteRenderer>();
        false1Sprite = false1.GetComponent<SpriteRenderer>();
        false2Sprite = false2.GetComponent<SpriteRenderer>();

        RandomizePosition();

    }
    public void RandomizePosition(){
        ++score;
        textScore.text="Score: " + score;
        Bounds bounds = this.gridArea.bounds;

        float x1 = Random.Range(bounds.min.x,bounds.max.x);
        float y1 = Random.Range(bounds.min.y,bounds.max.y);

        float x2 = Random.Range(bounds.min.x,bounds.max.x);
        float y2 = Random.Range(bounds.min.y,bounds.max.y);

        float x3 = Random.Range(bounds.min.x,bounds.max.x);
        float y3 = Random.Range(bounds.min.y,bounds.max.y);

        goal.transform.position = new Vector3(Mathf.Round(x1),Mathf.Round(y1),0.0f);
        if(Vector2.Distance(goal.transform.position,player.transform.position)< 2f){
            goal.transform.position = new Vector3(Mathf.Round(x1),Mathf.Round(y1),0.0f);
        }


        false1.transform.position = new Vector3(Mathf.Round(x2),Mathf.Round(y2),0.0f);
        if(Vector2.Distance(false1.transform.position,player.transform.position)< 2f  || Vector2.Distance(false1.transform.position,goal.transform.position)<2f ){
            false1.transform.position = new Vector3(Mathf.Round(x1),Mathf.Round(y1),0.0f);
        }

        false2.transform.position = new Vector3(Mathf.Round(x3),Mathf.Round(y3),0.0f);
        if(Vector2.Distance(false2.transform.position,player.transform.position)<2f || Vector2.Distance(false2.transform.position,goal.transform.position)<2f ){
            false2.transform.position = new Vector3(Mathf.Round(x1),Mathf.Round(y1),0.0f);
        }
        randomN = Random.Range(0, colorz.Length);
        textCol.text = "Pick up the " + colorz[randomN].name + " box!";
        goalSprite.color = colorz[randomN].myColor;

        int randomN2 = Random.Range(0, colorz.Length-1);
        if(randomN2==randomN){
            while(randomN2==randomN){
                randomN2 = Random.Range(0, colorz.Length-1);
            }
        }
        false1Sprite.color= colorz[randomN2].myColor;

         int randomN3 = Random.Range(0, colorz.Length-1);
        if(randomN3==randomN || randomN3== randomN2){
            while(randomN3==randomN || randomN3== randomN2){
                randomN3 = Random.Range(0, colorz.Length-1);
            }
        }
        false2Sprite.color= colorz[randomN3].myColor;
    }





    void OnTriggerEnter2D(Collider2D other){

        if(other.CompareTag("Player")){

            RandomizePosition();
            
        }

    }


    public void loseSnake(){
            scoreMenu.SetText(""+score);
            correctColor.SetText(""+colorz[randomN].name);
            correctColor.color = colorz[randomN].myColor;
    }


}
