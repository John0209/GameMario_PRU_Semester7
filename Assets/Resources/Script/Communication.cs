using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Communication : MonoBehaviour
{
    public Text txt_mario;
    public Text txt_princess;
    public GameObject mario_panel;
    public GameObject princess_panel;
    public GameObject mario_limit1;
    public GameObject mario_limit2;

    public void ActivePanelPrincess()
    {
        princess_panel.SetActive(true);
    }
    public void ActiveCommunicate()
    {
        mario_limit1.SetActive(true);
        mario_limit2.SetActive(true);
        mario_panel.SetActive(true);
        StartCoroutine(Communicate());
    }
    IEnumerator Communicate()
    {
        txt_mario.text = "Công Chúa Có Sao Không ?";
        yield return new WaitForSeconds(2);
        txt_princess.text = "Em Không Sao";
        yield return new WaitForSeconds(2);
        txt_princess.text = "Cảm Ơn Anh Đã Cứu Em";
        yield return new WaitForSeconds(2);
        txt_mario.text = "Đó Là Điều Anh Nên Làm";
        yield return new WaitForSeconds(2);
        txt_princess.text = "Mario, Không Biết Báo Đáp Anh Thế Nào";
        yield return new WaitForSeconds(2);
        txt_princess.text = "Em Xin Nguyện Dùng Cả Đời Này";
        yield return new WaitForSeconds(2);
        txt_princess.text = "Để Ở Bên Cạnh Chăm Sóc Anh";
        yield return new WaitForSeconds(2);
        txt_princess.text = "Anh Có Đồng Ý Không ?";
        yield return new WaitForSeconds(2);
        txt_mario.text = "Thật Sao, Đây Là Điều Anh Hằng Mong Ước";
        yield return new WaitForSeconds(2);
        txt_mario.text = "Peach, Mình Cưới Nhau Em Nhé";
        yield return new WaitForSeconds(2);
        txt_princess.text = "Vâng, Em Nghe Theo Anh";
        yield return new WaitForSeconds(2);

        mario_limit1.SetActive(false);
        mario_limit2.SetActive(false);
        princess_panel.SetActive(false);
        mario_panel.SetActive(false);
    }
}
