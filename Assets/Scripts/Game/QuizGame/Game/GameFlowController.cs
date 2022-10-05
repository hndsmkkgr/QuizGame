using Agate.MVC.Base;
using ExampleGame.Module.Global;
using ExampleGame.Message;

namespace ExampleGame.Module.QuizGame
{
    public class GameFlowController : BaseController<GameFlowController>
    {
        private CountdownController _countdown;
        private AnalyticController _analytic;
        private DatabaseController _dataBase;

        public void StartGame(int time)
        {            
            _countdown.SetCountdown(time);
            _countdown.EnableCountdown(true);
        }
        
        public void TimeOut()
        {
            _countdown.EnableCountdown(false);
        }

        public void SendData(string level)
        {
            _analytic.SendLevelCompleteAnalytic(level);
        }

        public void GiveReward(int coin)
        {
            Publish<UpdateCoinMessage>(new UpdateCoinMessage(coin));
        }
    }
}