using System.Linq;
using Controls;
using UnityEngine.SceneManagement;

namespace GameLoop
{
    public class GameLoopSandbox
    {
        private const int ArrayLenghtOffset = 1;
        
        private readonly Control[] _controls;

        private int _currentControllerTurnId;

        public GameLoopSandbox(Control[] controls)
        {
            _controls = controls;
        }

        public void BeginLoop()
        {
            _controls[_currentControllerTurnId].Begin();
            _controls[_currentControllerTurnId].Finished += TurnController_OnFinished;
        }

        private void TurnController_OnFinished()
        {
            _controls[_currentControllerTurnId].Finished -= TurnController_OnFinished;
            
            if (TryFinish()) 
                return;
            
            UpdatePrevTurn(_currentControllerTurnId);
            
            _currentControllerTurnId = CalculateNextControllerId(_currentControllerTurnId);

            _controls[_currentControllerTurnId].Finished += TurnController_OnFinished;
            _controls[_currentControllerTurnId].Begin();
        }

        private int CalculateNextControllerId(int currentId) => 
            currentId + ArrayLenghtOffset == _controls.Length ? 0 : ++currentId;

        private void UpdatePrevTurn(int turnId)
        {
            ControllableUnits controllable = turnId - ArrayLenghtOffset < 0
                ? _controls[^ArrayLenghtOffset].Controllable
                : _controls[turnId - ArrayLenghtOffset].Controllable;

            controllable.CallFinishTurn();
        }

        private bool TryFinish()
        {
            if (_controls.Select(c => c.Controllable).Count(t => t.IsTeamAlive) > 1) 
                return false;
            
            FinishLoop();
            return true;
        }

        private void FinishLoop() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}