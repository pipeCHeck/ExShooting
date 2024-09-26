using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] cardPrefab; // 카드의 프리팹 (UI 또는 2D 스프라이트)
    public int cardQuantity; // 한 번에 띄울 카드 장수

    List<GameObject> createCards = new List<GameObject>(); // 생성된 카드 목록
    GameObject[] cardObjects; // 실제 생성된 카드 오브젝트

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

    // 카드 랜덤 선택 메서드
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

    // 카드 생성 메서드
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

    // 카드 클릭 시 호출되는 메서드
    public void OnCardClicked()
    {
        for (int i = 0;i < cardQuantity;i++)
        {
            Destroy(cardObjects[i].gameObject);
        }

        createCards.Clear();
    }
}
