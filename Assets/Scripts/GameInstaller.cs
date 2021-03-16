using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public RoadManager roadPool;
    public override void InstallBindings()
    {
        Container.Bind<RoadManager>().FromInstance(roadPool).AsSingle();
        Container.Bind<RoadShapeFactory>().AsSingle();
    }
}