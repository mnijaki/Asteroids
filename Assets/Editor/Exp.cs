
//public class Exp : Editor {
//  string[] projectContent = AssetDatabase.GetAllAssetPaths();
//  PackageExporter pe;

//   AssetDatabase.ExportPackage("Assets/FolderToExport", "X:/Path/To/Your/Save/Location/PackageName.unitypackage", ExportPackageOptions.IncludeDependencies | ExportPackageOptions.Recurse);

//  //ExportPackageOptions.
//  //AssetDatabase.ExportPackage(projectContent, "UltimateTemplate.unitypackage", ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets );  
//  //Debug.Log("Project Exported"); 

//  // static void ExportPackage(string[] assetPathNames,string fileName,ExportPackageOptions flags = ExportPackageOptions.Default);

// // AssetDatabase.ExportPackage("Assets", "Entire Project.unitypackage",ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets|ExportPackageOptions.IncludeDependencies    );

//}


using UnityEngine;
using UnityEditor;

public class Exp
{
  [MenuItem("Export/ExportFullPackage")]
  static void export()
  {
    // AssetDatabase.ExportPackage("Assets","ZombieShooterPackage.unitypackage",ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets|ExportPackageOptions.IncludeDependencies);
    AssetDatabase.ExportPackage("Assets","Entire Project.unitypackage",ExportPackageOptions.Interactive | ExportPackageOptions.Recurse | ExportPackageOptions.IncludeLibraryAssets|ExportPackageOptions.IncludeDependencies);
  }

}
