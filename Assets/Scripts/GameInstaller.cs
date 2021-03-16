using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public RoadPool roadPool;
    public override void InstallBindings()
    {
        Container.Bind<RoadPool>().FromInstance(roadPool).AsSingle();
        Container.Bind<RoadPartFactory>().AsSingle();
    }
}