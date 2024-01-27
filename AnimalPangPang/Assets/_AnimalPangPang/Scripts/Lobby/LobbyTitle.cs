using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyTitle : MonoBehaviour
{

    public enum Title_BtnType
    {
        None = -1,
        Start,
        Shop,
        Exit,
    }

    [SerializeField] private List<Button> btnList;

    [SerializeField] private GameObject go_Notice;
    [SerializeField] private Button btn_NoticeBack;
    [SerializeField] private Button btn_NoticeClose;

    private void Awake()
    {
        go_Notice.SetActive(false);

        for (int i = 0; i < btnList.Count; i++)
        {
            int index = i;
            btnList[index].onClick.AddListener(() =>
            {
                OnClickTitleBtn(index);
            });
        }

        btn_NoticeBack.onClick.AddListener(() => go_Notice.SetActive(false));
        btn_NoticeClose.onClick.AddListener(() => go_Notice.SetActive(false));
    }


    private void OnClickTitleBtn(int btnTypeIndex)
    {
        var btnType = (Title_BtnType)btnTypeIndex;

        
        switch (btnType)
        {
            case Title_BtnType.Start:
                SceneManager.LoadScene("SceneMain");
                break;
            case Title_BtnType.Shop:
                go_Notice.SetActive(true);
                break;
            case Title_BtnType.Exit:
                Application.Quit();
                break;
        }
    }
}
