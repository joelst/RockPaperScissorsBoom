﻿namespace RockPaperScissor.Core.Game.Results
{
    public class RoundResult
    {
        public IBot Winner { get; set; }
        public IBot Player1 { get; set; }
        public IBot Player2 { get; set; }
        public Decision Player1Played { get; set; }
        public Decision Player2Played { get; set; }

        public PreviousDecisionResult ToPlayerSpecific(IBot bot)
        {
            var result = new PreviousDecisionResult();

            if (Winner == null)
            {
                result.Outcome = RoundOutcome.Tie;
            }
            else if (bot == Winner)
            {
                result.Outcome = RoundOutcome.Win;
            }
            else
            {
                result.Outcome = RoundOutcome.Loss;
            }

            if (bot == Player1)
            {
                result.YourPrevious = Player1Played;
                result.OpponentPrevious = Player2Played;
            }
            else
            {
                result.YourPrevious = Player2Played;
                result.OpponentPrevious = Player1Played;
            }

            return result;
        }
    }
}