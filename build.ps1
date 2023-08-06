
dotnet build src/UnityExplorer.sln -c Release_ML_Cpp_net6_interop
$Path = "Release\UnityExplorer.MelonLoader.IL2CPP.net6preview.interop"
# ILRepack
lib/ILRepack.exe /target:library /lib:lib/net6 /lib:$Path /internalize /out:Release/UnityExplorer.TLD.dll $Path/UnityExplorer.ML.IL2CPP.net6preview.interop.dll $Path/mcs.dll $Path/UniverseLib.IL2CPP.Interop.ML.dll
# (cleanup and move files)
Remove-Item $Path -Force -Recurse