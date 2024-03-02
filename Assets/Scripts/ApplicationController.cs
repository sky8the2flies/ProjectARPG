using System.Collections;
using sky8the2flies.Infrastructure;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

public class ApplicationController : LifetimeScope
{
    [SerializeField]
    UpdateRunner m_UpdateRunner;
    [SerializeField]
    NetworkManager m_NetworkManager;

    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);
        builder.RegisterComponent(m_UpdateRunner);
        builder.RegisterComponent(m_NetworkManager);
    }
    
    private void Start()
    {
        Application.wantsToQuit += OnWantToQuit;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(m_UpdateRunner.gameObject);
        Application.targetFrameRate = 120;
        SceneManager.LoadScene("MainMenu");
    }
    
    private IEnumerator LeaveBeforeQuit()
    {
        yield return null;
        Application.Quit();
    }
    
    private bool OnWantToQuit()
    {
        Application.wantsToQuit -= OnWantToQuit;
        

        return true;
    }

}
