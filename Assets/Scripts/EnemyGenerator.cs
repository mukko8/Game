using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy3;
    public GameObject Enemy4;
    float span=1.0f;
    float delta=0;
    int ratio=2;
    float speed=-0.03f;

    public void SetParameter(float span,float speed,int ratio){
        this.span=span;
        this.speed=speed;
        this.ratio=ratio;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta+=Time.deltaTime;
        if(this.delta>this.span){
            this.delta=0;
            GameObject item;
            int dice=Random.Range(1,11);
            if(dice<=this.ratio){
                item=Instantiate(Enemy1);
            }else{
                item=Instantiate(Enemy3);
                item=Instantiate(Enemy4);
            }
            float x=Random.Range(-1,2);
            float z=Random.Range(-1,2);
            item.transform.position=new Vector3(x,4,z);
            //item.GetComponent<ItemController>().dropSpeed=this.speed;
        }   
    }
}

