using UnityEngine;
using Zenject;

public class ManagerInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.BindInstance(new EventManager());
        // Container.BindInstance(gameObject.AddComponent<GameManager>());
    }
}
