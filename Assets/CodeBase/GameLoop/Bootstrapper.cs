using System;
using System.Collections.Generic;
using System.Linq;
using BattleSystem.Buffs;
using Controls;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Views;

namespace GameLoop.Buffs
{
    public class Bootstrapper : MonoBehaviour
    {
        [Header("Left team")]
        [SerializeField] private Unit[] leftTeam;
        [SerializeField] private AttackButton leftTeamAttackButton;
        [SerializeField] private ApplyBuffButton leftTeamApplyBuffButton;
        [SerializeField] private ActiveBuffsView leftTeamBuffView;
        [SerializeField] private BuffView leftTeamBuffPrefab;
        [FormerlySerializedAs("_leftTeamaAmorSlider")] [SerializeField] private Slider leftTeamaAmorSlider;
        [FormerlySerializedAs("_leftTeamHealthSlider")] [SerializeField] private Slider leftTeamHealthSlider;
        
        [Header("Right team")]
        [SerializeField] private Unit[] rightTeam;
        [SerializeField] private AttackButton rightTeamAttackButton;
        [SerializeField] private ApplyBuffButton rightTeamApplyBuffButton;
        [SerializeField] private ActiveBuffsView rightTeamBuffView;
        [SerializeField] private BuffView rightTeamBuffPrefab;
        [SerializeField] private Slider _rightTeamaAmorSlider;
        [SerializeField] private Slider _rightTeamHealthSlider;

        private List<IDisposable> _disposables = new List<IDisposable>();

        private void Start()
        {
            var buffApplier = new BuffApplier();
            var buffCollection = new BuffsCollection();

            var left = new Control(buffCollection, buffApplier, new ControllableUnits(leftTeam), new TargetFounder(rightTeam));
            var right = new Control(buffCollection, buffApplier, new ControllableUnits(rightTeam), new TargetFounder(leftTeam));
            
            rightTeamAttackButton.Construct(right);
            rightTeamApplyBuffButton.Construct(right);
            rightTeamBuffView.Construct(right.Controllable.Units, new BuffViewFactory(rightTeamBuffPrefab));
            var rightTeamArmorView = new AmorView(rightTeam.First(u => u.Health > 0).ArmorSystem, _rightTeamaAmorSlider);
            var rightTeamHealthView = new HealthView(rightTeam.First(u => u.Health > 0), _rightTeamHealthSlider);
            
            
            leftTeamAttackButton.Construct(left);
            leftTeamApplyBuffButton.Construct(left);
            leftTeamBuffView.Construct(left.Controllable.Units, new BuffViewFactory(leftTeamBuffPrefab));
            var leftTeamArmorView = new AmorView(leftTeam.First(u => u.Health > 0).ArmorSystem, leftTeamaAmorSlider);
            var leftTeamHealthView = new HealthView(leftTeam.First(u => u.Health > 0), leftTeamHealthSlider);

            _disposables.Add(leftTeamArmorView);
            _disposables.Add(leftTeamHealthView);
            _disposables.Add(rightTeamArmorView);
            _disposables.Add(rightTeamHealthView);
            
            var gameLoop = new GameLoopSandbox(new[]
            {
                left,
                right,
            });
            
            gameLoop.BeginLoop();
        }

        private void OnDestroy()
        {
            foreach (IDisposable disposable in _disposables) 
                disposable.Dispose();
        }
    }
}