using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Windows;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RaWindow : EditorWindow
{
    private string notification = " Folders Created!";
    private int m_FolderAmount;

    private string[] toolbarStrings = { "Folders", "UI"};
    private int toolBar = 0;

    #region Folder Vars
    private bool basicFolders = false;
    private string m_Name;
    private string m_location;

    //Dev Folders
    private bool scriptFolder = false;
    //Art Folders
    private bool animationFolder = false;
    private bool modelFolder = false;
    private bool materialFolder = false;
    private bool spriteFolder = false;
    //Other Folders
    private bool prefabFolder = false;
    private bool soundFolder = false;
    private bool resourceFolder = false;
    private bool editorFolder = false;
    #endregion
    #region UI Vars
    private GameObject myCanvas;
    private GameObject button;
    private GameObject text;
    private GameObject image;
    private GameObject slider;
    private GameObject eventSystem;
    private GameObject dropdown;

    private int amountDropdown;
    private int amountSlider;
    private int amountImage;
    private int amountTexts;
    private int amountButtons;
    #endregion

    [MenuItem("Tools/RA-Tool")]

    public static void Open()
    {
        RaWindow _window = GetWindow(typeof(RaWindow)) as RaWindow;
        _window.position = new Rect(100, 100, 220, 516);
        _window.minSize = new Vector2(220, 546);
        _window.maxSize = new Vector2(220, 546);
        _window.Show();
    }

    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        toolBar = GUILayout.Toolbar(toolBar, toolbarStrings);
        GUILayout.EndHorizontal();
        switch (toolBar)
        {
            case 0:
                #region Tab Folders
                GUILayout.Label("Choose what folders to create", EditorStyles.boldLabel);
                if (GUILayout.Button("Select all folders"))
                {
                    scriptFolder = true;
                    animationFolder = true;
                    modelFolder = true;
                    materialFolder = true;
                    spriteFolder = true;
                    prefabFolder = true;
                    soundFolder = true;
                    resourceFolder = true;
                    editorFolder = true;

                }
                if (GUILayout.Button("Deselect all folders"))
                {
                    scriptFolder = false;
                    animationFolder = false;
                    modelFolder = false;
                    materialFolder = false;
                    spriteFolder = false;
                    prefabFolder = false;
                    soundFolder = false;
                    resourceFolder = false;
                    editorFolder = false;
                }
                GUILayout.Label("");

                GUILayout.Label("Dev Folders", EditorStyles.boldLabel);
                scriptFolder = EditorGUILayout.Toggle("Script Folder", scriptFolder);
                GUILayout.Label("");

                GUILayout.Label("Art Folders", EditorStyles.boldLabel);
                materialFolder = EditorGUILayout.Toggle("Material Folder", materialFolder);
                spriteFolder = EditorGUILayout.Toggle("Sprite Folder", spriteFolder);
                modelFolder = EditorGUILayout.Toggle("Model Folder", modelFolder);
                animationFolder = EditorGUILayout.Toggle("Animation Folder", animationFolder);
                GUILayout.Label("");

                GUILayout.Label("Other Folders", EditorStyles.boldLabel);
                prefabFolder = EditorGUILayout.Toggle("Prefab Folder", prefabFolder);
                soundFolder = EditorGUILayout.Toggle("Sound Folder", soundFolder);
                resourceFolder = EditorGUILayout.Toggle("Resource Folder", resourceFolder);
                editorFolder = EditorGUILayout.Toggle("Editor Folder", editorFolder);
                GUILayout.Label("");

                if (GUILayout.Button("Create Folders"))
                {
                    CreateFolders();
                }
                GUILayout.Label("--------------------------------------------------");

                GUILayout.Label("Want an other Folder?", EditorStyles.boldLabel);
                GUILayout.Label("Folder Name");
                m_Name = GUILayout.TextField(m_Name);
                if (GUILayout.Button("Create Named Folder"))
                {
                    if (m_Name != "")
                    {
                        CreateNamedFolder();
                    }
                }
                GUILayout.Label("----------------------------------------------------------");
                if (GUILayout.Button("Info About Me"))
                {
                    Application.OpenURL("https://dannydkokgamedeveloper.wordpress.com/");
                }
            #endregion
                break;
            case 1:
                #region Tab UI
                GUILayout.Label("Create a Canvas", EditorStyles.boldLabel);
                if (GUILayout.Button("Create Canvas"))
                {
                    CreateCanvas();
                }
                GUILayout.Label("Create a EventSystem", EditorStyles.boldLabel);
                if (GUILayout.Button("Create EventSystem"))
                {
                    CreateEventSystem();
                }
                GUILayout.Label("");
                GUILayout.Label("Buttons", EditorStyles.boldLabel);
                amountButtons = EditorGUILayout.IntSlider(amountButtons, 1, 10);
                if (GUILayout.Button("Create Button(s)"))
                {
                    CreateButtons();
                }
                GUILayout.Label("");
                GUILayout.Label("Texts", EditorStyles.boldLabel);
                amountTexts = EditorGUILayout.IntSlider(amountTexts, 1, 10);
                if (GUILayout.Button("Create Text(s)"))
                {
                    CreateTexts();
                }
                GUILayout.Label("");
                GUILayout.Label("Images", EditorStyles.boldLabel);
                amountImage = EditorGUILayout.IntSlider(amountImage, 1, 10);
                if (GUILayout.Button("Create Image(s)"))
                {
                    CreateImages();
                }
                GUILayout.Label("");
                GUILayout.Label("Sliders", EditorStyles.boldLabel);
                amountSlider = EditorGUILayout.IntSlider(amountSlider, 1, 10);
                if (GUILayout.Button("Create Slider(s)"))
                {
                    CreateSliders();
                }
                GUILayout.Label("");
                GUILayout.Label("Dropdowns", EditorStyles.boldLabel);
                amountDropdown = EditorGUILayout.IntSlider(amountDropdown, 1, 10);
                if (GUILayout.Button("Create Dropdown(s)"))
                {
                    CreateDropdowns();
                }
                GUILayout.Label("----------------------------------------------------------");
                if (GUILayout.Button("Info About Me"))
                {
                    Application.OpenURL("https://dannydkokgamedeveloper.wordpress.com/");
                }
                #endregion
                break;
        }
    }

    private void CreateFolders()
    {
        m_FolderAmount = 0;

        if (!Directory.Exists("Assets/Dev Folders"))
        {
            string dev = AssetDatabase.CreateFolder("Assets", "Dev Folders");
            string devFolderPath = AssetDatabase.GUIDToAssetPath(dev);
            m_FolderAmount++;
        }
        if (!Directory.Exists("Assets/Art Folders"))
        {
            string art = AssetDatabase.CreateFolder("Assets", "Art Folders");
            string artFolderPath = AssetDatabase.GUIDToAssetPath(art);
            m_FolderAmount++;
        }
        if (!Directory.Exists("Assets/Other Folders"))
        {
            string other = AssetDatabase.CreateFolder("Assets", "Other Folders");
            string otherFolderPath = AssetDatabase.GUIDToAssetPath(other);
            m_FolderAmount++;
        }

        if (scriptFolder)
        {
            if (!Directory.Exists("Assets/Dev Folders/Scripts"))
            {
                string fold = AssetDatabase.CreateFolder("Assets/Dev Folders", "Scripts");
                string newFolderPath = AssetDatabase.GUIDToAssetPath(fold);
                m_FolderAmount++;
            }
        }
        if (materialFolder)
        {
            if (!Directory.Exists("Assets/Art Folders/Materials"))
            {
                string fold = AssetDatabase.CreateFolder("Assets/Art Folders", "Materials");
                string newFolderPath = AssetDatabase.GUIDToAssetPath(fold);
                m_FolderAmount++;
            }
        }
        if (spriteFolder)
        {
            if (!Directory.Exists("Assets/Art Folders/Sprites"))
            {
                string fold = AssetDatabase.CreateFolder("Assets/Art Folders", "Sprites");
                string newFolderPath = AssetDatabase.GUIDToAssetPath(fold);
                m_FolderAmount++;
            }
        }
        if (modelFolder)
        {
            if (!Directory.Exists("Assets/Art Folders/Models"))
            {
                string fold = AssetDatabase.CreateFolder("Assets/Art Folders", "Models");
                string newFolderPath = AssetDatabase.GUIDToAssetPath(fold);
                m_FolderAmount++;
            }
        }
        if (animationFolder)
        {
            if (!Directory.Exists("Assets/Art Folders/Animations"))
            {
                string fold = AssetDatabase.CreateFolder("Assets/Art Folders", "Animations");
                string newFolderPath = AssetDatabase.GUIDToAssetPath(fold);
                m_FolderAmount++;
            }
        }
        if (prefabFolder)
        {
            if (!Directory.Exists("Assets/Other Folders/Prefabs"))
            {
                string fold = AssetDatabase.CreateFolder("Assets/Other Folders", "Prefabs");
                string newFolderPath = AssetDatabase.GUIDToAssetPath(fold);
                m_FolderAmount++;
            }
        }
        if (soundFolder)
        {
            if (!Directory.Exists("Assets/Other Folders/Sounds"))
            {
                string fold = AssetDatabase.CreateFolder("Assets/Other Folders", "Sounds");
                string newFolderPath = AssetDatabase.GUIDToAssetPath(fold);
                m_FolderAmount++;
            }
        }
        if (resourceFolder)
        {
            if (!Directory.Exists("Assets/Other Folders/Resources"))
            {
                string fold = AssetDatabase.CreateFolder("Assets/Other Folders", "Resources");
                string newFolderPath = AssetDatabase.GUIDToAssetPath(fold);
                m_FolderAmount++;
            }
        }
        if (editorFolder)
        {
            if (!Directory.Exists("Assets/Other Folders/Editor"))
            {
                string fold = AssetDatabase.CreateFolder("Assets/Other Folders", "Editor");
                string newFolderPath = AssetDatabase.GUIDToAssetPath(fold);
                m_FolderAmount++;
            }
        }

        ShowNotification(new GUIContent(m_FolderAmount + notification));
    }

    private void CreateNamedFolder()
    {
        if (!Directory.Exists("Assets/Other Folders"))
        {
            string other = AssetDatabase.CreateFolder("Assets", "Other Folders");
            string otherFolderPath = AssetDatabase.GUIDToAssetPath(other);
        }

        string namedFold = AssetDatabase.CreateFolder("Assets/Other Folders", m_Name);
        string newNamedFolderPath = AssetDatabase.GUIDToAssetPath(namedFold);

        ShowNotification(new GUIContent("Folder Made"));
    }

    private void CreateCanvas()
    {
        if (FindObjectOfType<Canvas>() == null)
        {
            myCanvas = Instantiate((GameObject)Resources.Load("Canvas"));
            myCanvas.name = "Canvas";
            myCanvas.transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            ShowNotification(new GUIContent("There already is a Canvas"));
        }
    }

    private void CreateButtons()
    {
        if (FindObjectOfType<Canvas>() == null)
        {
            ShowNotification(new GUIContent("There isn't a Canvas"));
        }
        else
        {
            for (int i = 0; i < amountButtons; i++)
            {
                button = Instantiate((GameObject)Resources.Load("Button"));
                button.name = "Button";
                Canvas canvas = FindObjectOfType<Canvas>();
                button.transform.parent = canvas.transform;
                button.transform.localPosition = new Vector3(0, 0, 0);
                button.transform.localScale = new Vector3(1, 0.5f, 0);
            }
        }
    }

    private void CreateTexts()
    {
        if (FindObjectOfType<Canvas>() == null)
        {
            ShowNotification(new GUIContent("There isn't a Canvas"));
        }
        else 
        {
            for (int i = 0; i < amountTexts; i++)
            {
                text = Instantiate((GameObject)Resources.Load("Text"));
                text.name = "Text";
                Canvas canvas = FindObjectOfType<Canvas>();
                text.transform.parent = canvas.transform;
                text.transform.localPosition = new Vector3(0, 0, 0);
                text.transform.localScale = new Vector3(1, 1, 0);
            }
        }
    }

    private void CreateImages()
    {
        if (FindObjectOfType<Canvas>() == null)
        {
            ShowNotification(new GUIContent("There isn't a Canvas"));
        }
        else 
        { 
            for (int i = 0; i < amountImage; i++)
            {
                image = Instantiate((GameObject)Resources.Load("Image"));
                image.name = "Image";
                Canvas canvas = FindObjectOfType<Canvas>();
                image.transform.parent = canvas.transform;
                image.transform.localPosition = new Vector3(0, 0, 0);
                image.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void CreateSliders()
    {
        if (FindObjectOfType<Canvas>() == null)
        {
            ShowNotification(new GUIContent("There isn't a Canvas"));
        }
        else
        {
            for (int i = 0; i < amountSlider; i++)
            {
                slider = Instantiate((GameObject)Resources.Load("Slider"));
                slider.name = "Slider";
                Canvas canvas = FindObjectOfType<Canvas>();
                slider.transform.parent = canvas.transform;
                slider.transform.localPosition = new Vector3(0, 0, 0);
                slider.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void CreateDropdowns()
    {
        if (FindObjectOfType<Canvas>() == null)
        {
            ShowNotification(new GUIContent("There isn't a Canvas"));
        }
        else
        {
            for (int i = 0; i < amountDropdown; i++)
            {
                dropdown = Instantiate((GameObject)Resources.Load("Dropdown"));
                dropdown.name = "Dropdown";
                Canvas canvas = FindObjectOfType<Canvas>();
                dropdown.transform.parent = canvas.transform;
                dropdown.transform.localPosition = new Vector3(0, 0, 0);
                dropdown.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    private void CreateEventSystem()
    {
        if (FindObjectOfType<EventSystem>() == null)
        {
            eventSystem = Instantiate((GameObject)Resources.Load("EventSystem"));
            eventSystem.name = "EventSystem";
        }
        else
        {
            ShowNotification(new GUIContent("There already is a EventSystem"));
        }
    }
}