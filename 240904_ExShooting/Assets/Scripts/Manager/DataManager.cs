using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//���� ������ ���� �� ������ ���� �ӽ����� �� �ִ� ��ũ��Ʈ 
public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public List<UI_PlayerDataInfo> scoreList = new List<UI_PlayerDataInfo>();

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else if(instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetPlayData(string initialName, int scoreData)
    {
        GameObject instanceObject = new GameObject("PlayerDataInfo"); // ���ο� GameObject ����
        UI_PlayerDataInfo instanceList = instanceObject.AddComponent<UI_PlayerDataInfo>(); // ������Ʈ �߰�
        instanceList.SetPlayerData(initialName, scoreData); // �ʵ带 �����ϴ� �޼��� ȣ��
        DontDestroyOnLoad(instanceObject);


        scoreList.Add(instanceList);
    }

}
