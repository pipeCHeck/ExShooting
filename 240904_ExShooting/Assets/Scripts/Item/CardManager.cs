using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] cardPrefab; // ī���� ������ (UI �Ǵ� 2D ��������Ʈ)
    public int cardQuantity; // �� ���� ��� ī�� ���

    List<GameObject> createCards = new List<GameObject>(); // ������ ī�� ���
    GameObject[] cardObjects; // ���� ������ ī�� ������Ʈ

    void Start()
    {
        cardObjects = new GameObject[cardQuantity];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            CardAppearance();
        }
    }

    void CardAppearance()
    {
        SelectRandomCards();
        CreateCardList();
    }

    // ī�� ���� ���� �޼���
    void SelectRandomCards()
    {
        for (int i = 0; i < cardQuantity; i++)
        {
            while(true)
            {
                bool overlap = false;
                GameObject card = cardPrefab[Random.Range(0, cardPrefab.Length)];
                for (int j = 0; j < createCards.Count; j++) 
                { 
                    if (card == createCards[j])
                    {
                        overlap = true;
                    }
                }
                if (!overlap)
                {
                    createCards.Add(card);
                    break;
                }
            }
        }
    }

    // ī�� ���� �޼���
    void CreateCardList()
    {
        for (int i = 0; i < cardQuantity; i++)
        {
            GameObject newCard = Instantiate(createCards[i], new Vector3(i * 2f, 0, 0), Quaternion.identity);
            CardObject cardObject = newCard.GetComponent<CardObject>();
            cardObject.Initialize(this);
            cardObjects[i] = cardObject.gameObject;
        }
    }

    // ī�� Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnCardClicked()
    {
        for (int i = 0;i < cardQuantity;i++)
        {
            Destroy(cardObjects[i].gameObject);
        }

        createCards.Clear();
    }
}
