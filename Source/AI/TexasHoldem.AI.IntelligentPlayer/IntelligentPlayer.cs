namespace TexasHoldem.AI.IntelligentPlayer
{
    using System;
    using Logic.Players;

    public class IntelligentPlayer : BasePlayer
    {
        public override string Name { get; }
        public override PlayerAction GetTurn(GetTurnContext context)
        {
            return PlayerAction.Fold();
        }
    }
}
