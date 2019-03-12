using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    private string[] phrases = new string[]
    {
        "Welcome to Seasonal Aggression, a game about defending your town by using plants to help you out!",
        "You must use your budget you have in order to help defend the town!",

        "Let's start the game by planting! First we need to plant soil for us to use!",
        "First, you can use the Mouse or Arrow Keys to hover over the tiles in the game.",
        "Left-Click or Press Spacebar on this tile in order to plant soil!",
        "Note how you spent $100 to place soil. Any empty spot in the middle 5 lanes can have soil, but for now we'll only use the middle lane.",
        "We're short on money after that purchase. Luckily we can make money by selling crops!",
        "Left-Click or Press Spacebar on the freshly planted soil in order to plant a new crop seed.",
        "Awesome! Now we have a crop. For now it is just a small seed, but let's give it some time to grow.",

        "Now our seedling has grown into a big carrot! Let's sell it, before winter comes!",
        "Right-Click or Press Spacebar when hovering over a crop to sell it.",
        "If you look in the corner, we made $80 from that! What a sale!",
        "If you sell a crop before it's fully grown, then you won't make as much money from it, so let them grow!",
        "Oh no! There's a bug coming now! We need some defense!",
        "Quick, plant us an Spring flower!",
        "Press Left-Shift to change from planting Crops to planting Flowers, then plant a flower on the soil!",
        "Fantastic! Now watch our Spring flower take that bug down!",
        "Flowers will help us defend ourselves from bugs, but keep in mind that crops can't attack.",
        "If you ever need to remove a flower, or any crop you planted, you can press Right-Click or Spacebar when hovering over a plant to remove it.",
        "If you need to pause the game, press Escape at any time.",

        "Every 30 seconds, the season will change, and enemies will become stronger and more resistant to your plants, so be weary and plant on!",
        "Each flower has it's favored season.",
        "The Spring flower does twice as much damage during the spring time.",
        "In Summer, the Summer Flower will shoot in a spread.",
        "During the Fall, the Fall Flower will double-shoot.",
        "Lastly, the Winter Flower will slow enemies down.",
        "Crops also change every season, but they don't change in prices.",
        "They won't sell for anything in the winter time, so be cautious of when you plan to have crops!",
    };
    private int currText;

    private int[] eventsArr = new int[] { };

    public Text textBox;
    public Button previousButton;
    public Button nextButton;
    public Button finishTutorial;

    // Start is called before the first frame update
    void Start()
    {
        currText = 0;
        previousButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(true);
        finishTutorial.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextText()
    {
        currText++;
        previousButton.gameObject.SetActive(true);
        if (currText == phrases.Length)
        {
            nextButton.gameObject.SetActive(false);
            finishTutorial.gameObject.SetActive(true);
        }
    }

    void PreviousText()
    {
        currText--;
        nextButton.gameObject.SetActive(true);
        if (currText == 0)
        {
            previousButton.gameObject.SetActive(false);
        }
    }

    /*void TutorialEvents(int eventNum)
    {
        switch (eventNum)
        {
            case 0:
                break;
            case 0:
                break;
            case 0:
                break;
            case 0:
                break;
            case 0:
                break;
            case 0:
                break;

            default:
                break;
        }
    }*/

    /*
     * Tutorial progression:
     * 
     * Part 1: Introduce Game
     *      Welcome to Seasonal Aggression, a game about defending your town by using plants to help you out!
     *      You must use your budget you have in order to help defend the town! (point to money)
     * 
     * Part 2: Introduce Controls
     *      Let's start the game by planting! First we need to plant soil for us to use!
     *      First, you can use the Mouse or Arrow Keys to hover over the tiles in the game.
     *      Left-Click or Press Spacebar on this tile in order to plant soil! (point to empty square)
     *      Note how you spent $100 to place soil. Any empty spot in the middle 5 lanes can have soil, but for now we'll only use the middle lane.
     *      We're short on money after that purchase. Luckily we can make money by selling crops!
     *      Left-Click or Press Spacebar on the freshly planted soil in order to plant a new crop seed. (point to soil)
     *      Awesome! Now we have a crop. For now it is just a small seed, but let's give it some time to grow. (Run time for 16 seconds)
     *      Now our seedling has grown into a big carrot! Let's sell it, before winter comes!
     *      Right-Click or Press Spacebar when hovering over a crop to sell it. (point to grown crop)
     *      If you look in the corner, we made $80 from that! What a sale! (point to money)
     *      If you sell a crop before it's fully grown, then you won't make as much money from it, so let them grow!
     *      Oh no! There's a bug coming now! We need some defense!
     *      Quick, plant us an Spring flower!
     *      Press Left-Shift to change from planting Crops to planting Flowers, then plant a flower on the soil! (point to soil)
     *      Fantastic! Now watch our Spring flower take that bug down! (run game for 10 seconds)
     *      Flowers will help us defend ourselves from bugs, but keep in mind that crops can't attack.
     *      If you ever need to remove a flower, or any crop you planted, you can press Right-Click or Spacebar when hovering over a plant to remove it.
     *      If you need to pause the game, press Escape at any time.
     *      
     * Part 3:
     *      Every 30 seconds, the season will change, and enemies will become stronger and more resistant to your plants, so be weary and plant on!
     *      Each flower has it's favored season.
     *      The Spring flower does twice as much damage during the spring time. (show Spring flower)
     *      In Summer, the Summer Flower will shoot in a spread. (show Summer flower)
     *      During the Fall, the Fall Flower will double-shoot. (show Fall flower)
     *      Lastly, the Winter Flower will slow enemies down. (show Winter flower)
     *      Crops also change every season, but they don't change in prices.
     *      They won't sell for anything in the winter time, so be cautious of when you plan to have crops!
     * 
    */
}
