using Nsu.ColiseumProblem.Contracts;
using Nsu.ColiseumProblem.Contracts.Cards;

namespace StrategyLibrary;

public class Strategy : ICardPickStrategy
{

    public int Pick(Card[] cards) // returns from 0 to 17; who == 0 -> Elon, who == 1 -> Mark
    {
        // go through your cards and see the first red (or black), then return this number
        // if nothing found, return whatever
        for (int i = 0; i < 18; i++)
        {
            if (cards[i].Color == CardColor.Red)
            {
                return i;
            }
        }
        return 0;
    }
}
