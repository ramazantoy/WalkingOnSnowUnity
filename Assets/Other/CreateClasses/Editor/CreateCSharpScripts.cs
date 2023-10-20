#if UNITY_EDITOR
using UnityEditor;

namespace CreateClasses
{
    public class CreateCSharpScripts
    {
        private const string path = "Assets/Other/CreateClasses/ClassTemplates/CSharpScripts/";

        #region EMPTY CLASS

        private const string emptyClassTemplate = "EmptyClass.cs.txt";

        [MenuItem(itemName: "Assets/Create/C# Class", isValidateFunction: false, priority: 51)]
        public static void CreateClassFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + emptyClassTemplate, "EmptyClass.cs");
        }

        #endregion

        #region ENUM
        private const string enumTemplate = "Enum.cs.txt";

        [MenuItem(itemName: "Assets/Create/C# Enum", isValidateFunction: false, priority: 51)]
        public static void CreateEnumFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + enumTemplate, "Enum.cs");
        }
        #endregion

        #region INTERFACE
        private const string interfaceTemplate = "Interface.cs.txt";

        [MenuItem(itemName: "Assets/Create/C# Interface", isValidateFunction: false, priority: 51)]
        public static void CreateInterfaceFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + interfaceTemplate, "Interface.cs");
        }
        #endregion

        #region STRUCT
        private const string structTemplate = "Struct.cs.txt";

        [MenuItem(itemName: "Assets/Create/C# Struct", isValidateFunction: false, priority: 51)]
        public static void CreateStructFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + structTemplate, "Struct.cs");
        }
        #endregion
    }
}
#endif
