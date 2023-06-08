using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    Vector3 locationOriginal;
    float m_bounce = 5;// tốc độ nảy
    float donay = 1f;// cộng thêm độ nhảy y 
    public GameObject m_hiddenItem;
    public GameObject m_unlock;
   
    // Start is called before the first frame update
    void Start()
    {
       // itemsHidden=FindObjectOfType<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnCollisionEnter2D(Collision2D col)
    {
        //mario nhảy lên lấy items
        if (col.collider.tag == "Player" && col.contacts[0].normal.y > 0)
        {
            locationOriginal = transform.localPosition;
            StartCoroutine(Bounce());
        }
        
    }
    
    IEnumerator Bounce()
    {
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + m_bounce * Time.deltaTime);
            if (transform.localPosition.y >= locationOriginal.y + donay) break;
            yield return null;
        }
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - m_bounce * Time.deltaTime);
            if (transform.localPosition.y <= locationOriginal.y) 
            {
                transform.localPosition = new Vector2(transform.localPosition.x, locationOriginal.y);
                break;
            }
            Destroy(gameObject);
            //GameObject itemsHidden = (GameObject)Instantiate(Resources.Load("Prefab/itemHidden"));
            //tạo ra objet mới khi nảy vào ?
            m_unlock.SetActive(true);
            m_unlock.transform.localPosition = locationOriginal;
            //nảy xu ra
            m_hiddenItem.SetActive(true);
            m_hiddenItem.transform.localPosition =new Vector2(locationOriginal.x, locationOriginal.y+1);
            yield return null;
        }
    }
    

}
