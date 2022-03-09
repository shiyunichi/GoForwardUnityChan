using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    public GameObject unityChan2D;

    public AudioClip block;
    AudioSource audioSource;

    
    // Start is called before the first frame update
    void Start()
    {
        //unityちゃん2Dオブジェクトを取得
        unityChan2D = GameObject.Find("UnityChan2D");

        //コンポーネントを取得
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破壊する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }


    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        //ユニティちゃんオブジェクトではない時
        if (col.gameObject.name != "UnityChan2D") 
        {
            //衝突時に音を鳴らす
            audioSource.PlayOneShot(block);

        }

    }

}
