using System.Runtime.CompilerServices;

using StrategyLibrary;
using Nsu.ColiseumProblem.Contracts;
using Nsu.ColiseumProblem.Contracts.Cards;

const int picks = 1000000;

void printArray(Card[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write("{0} ", array[i].Color);
    }
    Console.WriteLine("\n");
}

void shuffle(Card[] array){
    var rng = new Random();
    int n = array.Length;
        while (n > 1) 
        {
            int k = rng.Next(n--);
            Card temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
}

void split(Card[] deck, out Card[] deck1, out Card[] deck2){
    deck1 = deck.Take(18).ToArray();
    deck2 = deck.Skip(18).ToArray();
}

var deck = new Card[36];

var deck1 = new Card[18];
var deck2 = new Card[18];

// create a deck
for (int i = 0; i < 18; i++)
{
    deck[i] = new Card(CardColor.Red);
}
for (int i = 18; i < 36; i++)
{
    deck[i] = new Card(CardColor.Black);
}

int correct = 0;

ICardPickStrategy cardPickStrategy = new Strategy();
for (int i = 0; i < picks; i++)
{
    shuffle(deck);
    //printArray(deck);
    split(deck, out deck1, out deck2);
    //printArray(deck1);
    //printArray(deck2);

    int elon = cardPickStrategy.Pick(deck1);
    int mark = cardPickStrategy.Pick(deck2);
    if (deck2[elon].Color == deck1[mark].Color){
        correct++;
    }
}

Console.WriteLine(100 * (double)correct / picks);