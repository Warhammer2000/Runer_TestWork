using System;
using NUnit.Framework;
using Runer;
using UnityEditor;
using UnityEngine;
using Zenject;

[TestFixture]
public class PlayerMovement_StateIsCanMoveLeftOrRight_Test : ZenjectUnitTestFixture
{
    private PlayerMovementState testingInstance;

    [SetUp]
    public void CommonInstall()
    {
        var movementSettings = AssetDatabase.LoadAssetAtPath<MovementSettings>("Assets/Configs/MovementSettings.asset");
        Container.Bind<MovementSettings>().FromInstance(movementSettings);

        var traceSettings = AssetDatabase.LoadAssetAtPath<TraceSettings>("Assets/Configs/TraceSettings.asset");
        Container.Bind<TraceSettings>().FromInstance(traceSettings);

        Container.Bind<PlayerMovementState>().AsSingle();
    }

    [Test]
    public void TestZero()
    {
        testingInstance = Container.Resolve<PlayerMovementState>();
        bool result = testingInstance.IsCanMoveLeftOrRight(0);
        Assert.That(result, Is.True);
    }
}