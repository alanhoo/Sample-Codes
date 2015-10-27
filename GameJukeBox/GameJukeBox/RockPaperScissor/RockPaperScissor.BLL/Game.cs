using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJukeBox.RockPaperScissor.RockPaperScissor.Models;

namespace GameJukeBox.RockPaperScissor.RockPaperScissor.BLL
{
    class Game
    {
        private IChoiceSelector _myChoiceSelector;

        public Game(IChoiceSelector choiceSelector)
        {
            _myChoiceSelector = choiceSelector;
        }

        public MatchResults PlayRound(Choice userChoice)
        {
            var result = new MatchResults();
            result.UserChoice = userChoice;
            result.ComputerChoice = _myChoiceSelector.GetOpponentChoice();

            if (result.ComputerChoice == result.UserChoice)
            {
                result.Result = GameResults.Tie;
                return result;
            }

            if (result.ComputerChoice == Choice.Rock && result.UserChoice == Choice.Scissors ||
                result.ComputerChoice == Choice.Scissors && result.UserChoice == Choice.Paper ||
                result.ComputerChoice == Choice.Paper && result.UserChoice == Choice.Rock)
            {
                result.Result = GameResults.Loss;
                return result;
            }

            result.Result = GameResults.Win;
            return result;
        }
    }
}
