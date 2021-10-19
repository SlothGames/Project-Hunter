using UnityEngine;
using UnityEngine.UI;


public class CardDisplay : MonoBehaviour
{
    private GameObject cardObject;
    public GameObject shadow;
    public GameObject showCard;

    private Card card;

    private bool active;


    public void StartCard(Card target)
    {
        active = false;

        cardObject = this.gameObject;
        card = target;

        cardObject.GetComponent<Image>().sprite = target.background;
        cardObject.transform.GetChild(0).GetComponent<Image>().sprite = target.artWork;
        cardObject.transform.GetChild(1).GetComponent<Text>().text = target.manaCost.ToString();
        cardObject.transform.GetChild(2).GetComponent<Text>().text = target.name;
        cardObject.transform.GetChild(3).GetComponent<Text>().text = target.description;

        if (target.power == -1)
        {
            cardObject.transform.GetChild(4).GetComponent<Text>().text = "";
        }
        else
        {
            cardObject.transform.GetChild(4).GetComponent<Text>().text = target.power.ToString();
        }
    }


    /// <summary>
    /// Elementos de interacción con el ratón
    /// </summary>
    public void Enter()
    {
        shadow.gameObject.SetActive(true);
    }

    
    public void Exit()
    {
        shadow.gameObject.SetActive(false);
    }


    public void Click()
    {
        if(active)
        {
            active = false;
        }
        else
        {
            active = true;

            showCard.GetComponent<Image>().sprite = card.background;
            showCard.transform.GetChild(0).GetComponent<Image>().sprite = card.artWork;
            showCard.transform.GetChild(1).GetComponent<Text>().text = card.manaCost.ToString();
            showCard.transform.GetChild(2).GetComponent<Text>().text = card.name;
            showCard.transform.GetChild(3).GetComponent<Text>().text = card.description;

            if (card.power == -1)
            {
                showCard.transform.GetChild(4).GetComponent<Text>().text = "";
            }
            else
            {
                showCard.transform.GetChild(4).GetComponent<Text>().text = card.power.ToString();
            }
        }

        showCard.SetActive(active);
    }


    public void HideCard()
    {
        active = false;

        showCard.SetActive(active);
    }


    public void NotSelected()
    {
        active = false;
    }
}
