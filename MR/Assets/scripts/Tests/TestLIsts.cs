using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TestLIsts : MonoBehaviour
{
    public bool DoAddScene = false;
    public bool DoRemoveScene = false;
    public bool DoAddObject = false;
    public bool DoRemoveObject = false;
    int q = 0;

    [SerializeField]
    private List<string> _sceneNames = new List<string>();
    public List<string> sceneNames { 
        get { Debug.Log("get sceneNames"); return _sceneNames; }
        private set { Debug.Log("set sceneNames"); _sceneNames = value; }
    }

    [SerializeField]
    private List<GameObject> _allObjects = new List<GameObject>();
    public List<GameObject> allObjects {
        get { Debug.Log("get allObjects"); return _allObjects; }
        private set { Debug.Log("set allObjects"); _allObjects = value; }
    }

    [HideInInspector]
    public List<List<bool>> visibilityList2D = new List<List<bool>>();

    public class SceneNames
    {
        public delegate void OnVariableChangeDelegate(int indexChanged);
        public event OnVariableChangeDelegate OnVariableChange;
        private List<string> _sceneNames;

        public List<string> Get() { return _sceneNames; }
        public void Set(List<string> newList) { _sceneNames = newList; OnVariableChange(int.MaxValue); }

        public void Add()
        {

        }

        public void Remove()
        {

        }

        
    }


    private void Start()
    {
        //foreach (var sceneName in sceneNames)
        //{
        //    visibilityList2D.Add(Enumerable.Repeat(false, allObjects.Count).ToList());
        //}
    }

    private void Update()
    {
        if (DoAddScene)
        {
            sceneNames.Add(gameObject.name + q++);
            DoAddScene = false;
        }
        if (DoRemoveScene)
        {
            sceneNames.RemoveAt(1);
            DoRemoveScene = false;
        }
        if (DoAddObject) { 
            allObjects.Add(gameObject); 
            DoAddObject = false;
        }
        if (DoRemoveObject)
        {
            allObjects.RemoveAt(0);
            DoRemoveObject = false;
        }
    }
}
